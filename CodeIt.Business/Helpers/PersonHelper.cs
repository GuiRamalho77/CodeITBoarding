using CodeIt.Business.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodeIt.Business.Helpers
{
    public static class PersonHelper
    {
        public static Entities.Person generatePerson(string name, JobType type)
        {
            return new Entities.Person
            {
                Name = name,
                JobType = type
            };
        }

        public static string GenerateName(int len)
        {
            Random r = new Random();
            string[] consonants = { "b", "c", "d", "f", "g", "h", "j", "k", "l", "m", "l", "n", "p", "q", "r", "s", "sh", "zh", "t", "v", "w", "x" };
            string[] vowels = { "a", "e", "i", "o", "u", "ae", "y" };
            string Name = "";
            Name += consonants[r.Next(consonants.Length)].ToUpper();
            Name += vowels[r.Next(vowels.Length)];
            int b = 2;
            while (b < len)
            {
                Name += consonants[r.Next(consonants.Length)];
                b++;
                Name += vowels[r.Next(vowels.Length)];
                b++;
            }
            return Name;
        }

        public static List<Entities.Person> removePeopleBoarded(List<Entities.Person> rangeBoarded, List<Entities.Person> rangePeople)
        {
            for (var item = 0; item < rangeBoarded.Count; item++)
                rangePeople.Remove(rangeBoarded[item]);
            return rangePeople;
        }

        public static List<Entities.Person> convertToPerson(dynamic range)
        {
            var resultPerson = new List<Entities.Person>();
            foreach (var person in range)
            {
                var properties = person.GetType().GetProperties();
                var personRange = new Entities.Person
                {
                    Name = person.GetType().GetProperty(properties[0].Name).GetValue(person, null),
                    JobType = (Enums.JobType)person.GetType().GetProperty(properties[1].Name).GetValue(person, null)
                };
                resultPerson.Add(personRange);          
            }
            return resultPerson;
        }
    }
}
