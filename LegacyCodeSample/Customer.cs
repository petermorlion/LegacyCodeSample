using System;
using System.IO;
using System.Linq;

namespace LegacyCodeSample
{
    public class Customer
    {
        public int Id { get; set; }
        public bool IsGoldMember { get; set; }
        public DateTime Birthdate { get; set; }

        public bool IsEmployee()
        {
            var lines = File.ReadAllLines("database.txt");
            var person = lines.SingleOrDefault(x => x.StartsWith($"{Id};"));
            if (person == null)
            {
                throw new Exception("Employee not found");
            }

            var isEmployee = person.Split(';')[1];
            return isEmployee == "1";
        }
    }
}
