using System;
using System.Reflection.PortableExecutable;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PopulateDb.Models;

namespace PopulateDb
{
    class Program
    {
        static void Main(string[] args)
        {
            MainAsync().GetAwaiter().GetResult();
        }

        static async Task MainAsync(string[] args)
        {
            var runner = new Runner(new hw8Context(args[0]));
            await runner.RunAsync();
            Console.WriteLine("Done");
        }
    }
}
