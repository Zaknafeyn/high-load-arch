using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PopulateDb.Models;


namespace PopulateDb
{
    public class Runner
    {
        private readonly hw8Context _dbContext;
        private Random _random = new Random(DateTime.Now.Millisecond);

        public Runner(hw8Context dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task RunAsync(int itemsNumber = 1_000_000, int itemPortion = 100)
        {
            Console.WriteLine($"Generating {itemsNumber} fake records for DB");
            var iterations = itemsNumber / itemPortion;
            var fakeArray = new int [itemPortion];
            
            for (var i = 0; i < iterations; i++)
            {
                var records = fakeArray.Select(_ => GetDataRecord()).ToList();
                await InsertTempDataAsync(records);
                await Task.Delay(1500);
                Console.WriteLine($"{itemPortion} items inserted");
                if (i % itemPortion == 0)
                {
                    Console.WriteLine($"Processed {i * itemPortion} records ...");
                }
            }
        }

        private async Task InsertTempDataAsync(List<DataRecord1> records)
        {
            var rows = records.Select(GetTempRecord);
            await _dbContext.Temp.AddRangeAsync(rows);
            await _dbContext.SaveChangesAsync();
        }

        private DataRecord1 GetDataRecord()
        {
            var result = new DataRecord1
            {
                Name = GenName()
            };

            return result;
        }

        private Temp GetTempRecord(DataRecord1 record)
        {
            var result = new Temp
            {
                Name = record.Name
            };

            return result;
        }

        private string GenName(int minLen = 3, int maxLen = 30)
        {
            var wordLen = _random.Next(minLen, maxLen);
            var result = new StringBuilder();
            for (var i = 0; i < wordLen; i++)
            {
                result.Append(GetRandomChar());
            }

            return result.ToString();
        }

        private string GetRandomChar()
        {
            var code = _random.Next(97, 122);
            var result = ((char) code).ToString();
            return result;
        }
    }
}