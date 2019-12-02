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

        public async Task RunAsync(int itemsNumber = 2_000_000_000, int itemPortion = 1000)
        {
            Console.WriteLine($"Generating {itemsNumber} fake records for DB");
            var iterations = itemsNumber / itemPortion;
            var fakeArray = new int [itemPortion];
            for (var i = 0; i < iterations; i++)
            {
                var records = fakeArray.Select(_ => GetDataRecord()).ToList();
                await InsertInnodbDataAsync(records);
                await InsertMyisamDataAsync(records);
                if (i % 100 == 0)
                {
                    Console.WriteLine($"Processed {i * 100 * itemPortion} records ...");
                }
            }
        }

        private async Task InsertMyisamDataAsync(List<DataRecord> records)
        {
            var rows = records.Select(GetMyisamRecord);
            await _dbContext.Myisam.AddRangeAsync(rows);
            await _dbContext.SaveChangesAsync();
        }

        private async Task InsertInnodbDataAsync(List<DataRecord> records)
        {
            var rows = records.Select(GetInnodbRecord);
            await _dbContext.Innodb.AddRangeAsync(rows);
            await _dbContext.SaveChangesAsync();
        }

        private DataRecord GetDataRecord()
        {
            var day = GetDay();
            var month = GetMonth();
            var year = GetYear();
            var date = GetBirthDate(day, month, year);
            var result = new DataRecord
            {
                FirstName = GenName(),
                SecondName = GenName(),
                Phone = GetPhoneNumber(),
                BirthDay = day,
                BirthMonth = month,
                BirthYear = year,
                BirthDate = date
            };

            return result;
        }

        private Myisam GetMyisamRecord(DataRecord record)
        {
            var result = new Myisam
            {
                FirstName = record.FirstName,
                SecondName = record.SecondName,
                Phone = record.Phone,
                BirthDay = record.BirthDay,
                BirthMonth = record.BirthMonth,
                BirthYear = record.BirthYear,
                BirthDate = record.BirthDate,
            };

            return result;
        }

        private Innodb GetInnodbRecord(DataRecord record)
        {
            var result = new Innodb
            {
                FirstName = record.FirstName,
                SecondName = record.SecondName,
                Phone = record.Phone,
                BirthDay = record.BirthDay,
                BirthMonth = record.BirthMonth,
                BirthYear = record.BirthYear,
                BirthDate = record.BirthDate,
            };

            return result;
        }

        private string GetPhoneNumber()
        {
            var result = new StringBuilder();
            result.AppendFormat("+{0}{1}{2}", GetRandomDigit(), GetRandomDigit(), GetRandomDigit());
            result.AppendFormat("-{0}{1}", GetRandomDigit(), GetRandomDigit());
            result.AppendFormat("-{0}{1}{2}", GetRandomDigit(), GetRandomDigit(), GetRandomDigit());
            result.AppendFormat("-{0}{1}", GetRandomDigit(), GetRandomDigit());
            result.AppendFormat("-{0}{1}", GetRandomDigit(), GetRandomDigit());
            return result.ToString();
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

        private string GetRandomDigit()
        {
            var digit = _random.Next(0, 9);
            return digit.ToString();
        }

        private int GetDay()
        {
            return _random.Next(1, 28);
        }

        private int GetMonth()
        {
            return _random.Next(1, 12);
        }

        private int GetYear()
        {
            return _random.Next(1919, 2009);
        }
        private DateTime GetBirthDate(int day, int month, int year)
        {
            var result = new DateTime(year, month, day);
            return result;
        }
    }
}