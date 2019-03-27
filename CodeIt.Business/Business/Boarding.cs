using CodeIt.Business.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodeIt.Business.Business
{
    public class Boarding
    {
        private List<Entities.Person> returnRandonPerson()
        {
            var rangeOfPerson = new List<Entities.Person>();
            for (int i = 1; i <= 8; i++)
            {
                var person = PersonHelper.generatePerson(PersonHelper.GenerateName(8),
                    BordingHelper.rulesTripulationJobType(rangeOfPerson));

                rangeOfPerson.Add(person);
            }
            return rangeOfPerson;
        }

        public List<string> applyRules(dynamic rangePerson = null)
        {
            var ConsoleWrite = new List<string>();
            var rangeTreated = new List<Entities.Person>();

            if (rangePerson == null) rangeTreated = returnRandonPerson();
            else rangeTreated = PersonHelper.convertToPerson(rangePerson);
           

            var quantity = 1;
            for(var cont =0; quantity!=0;)
            {
                var rulesBording = BordingHelper.rulesBording(rangeTreated);
                if (rulesBording.peopleBoarded.Count > 0)
                    rangeTreated = Helpers.PersonHelper.removePeopleBoarded(rulesBording.peopleBoarded, rangeTreated);
                if (rulesBording.listWrite.Count > 0)
                    foreach (var write in rulesBording.listWrite)
                        ConsoleWrite.Add(write);
                quantity = rangeTreated.Count;
            }

            return ConsoleWrite;
        }
    }
}
