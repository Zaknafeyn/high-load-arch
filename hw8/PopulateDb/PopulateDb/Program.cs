using System;
using System.Reflection.PortableExecutable;
using System.Threading.Tasks;

namespace PopulateDb
{
    class Program
    {
        static void Main(string[] args)
        {
            var connectionString = "Server=192.168.2.102; Port=3306;User Id=<login>;Password=<pass>;Database=hw8";
            MainAsync().GetAwaiter();
        }

        static async Task MainAsync()
        {

        }
    }
}
