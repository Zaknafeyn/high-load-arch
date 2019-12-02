using System;

namespace PopulateDb.Models
{
    public partial class Innodb
    {
        public uint Id { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string Phone { get; set; }
        public DateTime BirthDate { get; set; }
        public int BirthDay { get; set; }
        public int BirthMonth { get; set; }
        public int BirthYear { get; set; }
    }
}
