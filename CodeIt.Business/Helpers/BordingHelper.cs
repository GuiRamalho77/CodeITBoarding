using CodeIt.Business.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeIt.Business.Helpers
{
    public static class BordingHelper
    {
        public static JobType rulesTripulationJobType(List<Entities.Person> rangePeople)
        {
            if (rangePeople.Count < 1) return JobType.Policial;

            var rangeOfJobType = new List<JobType>();

            foreach (var people in rangePeople) { rangeOfJobType.Add(people.JobType); }

            if (!rangeOfJobType.Contains(JobType.Presidiario)) return JobType.Presidiario;

            if (!rangeOfJobType.Contains(JobType.Piloto)) return JobType.Piloto;

            if (!rangeOfJobType.Contains(JobType.Oficial)) { return JobType.Oficial; }
            else
            {
                var quantity = rangePeople.Where(p => p != null && p.JobType == JobType.Oficial).Count();
                if (quantity == 1) return JobType.Oficial;
            }

            if (!rangeOfJobType.Contains(JobType.ChefeTripulacao)) { return JobType.ChefeTripulacao; }            

            if (!rangeOfJobType.Contains(JobType.Comissaria)) { return JobType.Comissaria; }
            else
            {
                var quantity = rangePeople.Where(p => p != null && p.JobType == JobType.Comissaria).Count();
                if (quantity == 1) return JobType.Comissaria;
            }
            return JobType.Invalid;
        }

        public static Entities.Log validRules(Entities.Person driver, Entities.Person passenger)
        {
            if ((driver.JobType == JobType.Policial && passenger.JobType == JobType.Presidiario)
                || (driver.JobType == JobType.Policial && passenger.JobType == JobType.Piloto
                || passenger.JobType == JobType.ChefeTripulacao))
                return Helpers.LogHelper.saveLog(true, driver, passenger);

            else if ((driver.JobType == JobType.Piloto && passenger.JobType == JobType.Oficial)
                || (driver.JobType == JobType.Piloto && passenger.JobType == JobType.ChefeTripulacao ||
                passenger.JobType == JobType.Policial))
                return Helpers.LogHelper.saveLog(true, driver, passenger);

            else if ((driver.JobType == JobType.ChefeTripulacao && passenger.JobType == JobType.Comissaria)
                || (driver.JobType == JobType.ChefeTripulacao && passenger.JobType == JobType.Policial ||
                passenger.JobType == JobType.Piloto))
                return Helpers.LogHelper.saveLog(true, driver, passenger);

            else return new Entities.Log { isValid = false };
        }

        public static dynamic rulesBording(List<Entities.Person> rangeTreated)
        {
            var quantityPiloto = 0;
            var quantityChef = 0;
            var personBording = new List<Entities.Person>();
            var listString = new List<string>();

            if (rangeTreated.Count == 1)
            {
                listString.Add($"O {rangeTreated[0].Name.ToUpper()} foi o ultimo a embarcar.");
                personBording.Add(rangeTreated[0]);
            }
                
            var driver = new Entities.Person();
            var passenger = new Entities.Person();

            foreach (var people in rangeTreated)
            {

                if (people.drive && string.IsNullOrEmpty(driver.Name))
                    driver = people;
                else if ((!people.drive && passenger.JobType != JobType.ChefeTripulacao 
                    && passenger.JobType != JobType.Policial && passenger.JobType != JobType.Piloto)
                    || (rangeTreated.Count == 4 && people.JobType == JobType.ChefeTripulacao))
                    passenger = people;
                else continue;

                if (driver.Name != null && passenger.Name != null)
                {
                    var validRule = Helpers.BordingHelper.validRules(driver: driver, passenger: passenger);
                    if (validRule.isValid)
                    {
                        listString.Add(validRule.Message);
                        personBording.Add(passenger);
                        passenger = new Entities.Person();

                        if (driver.JobType == Enums.JobType.Policial)
                        {
                            passenger = driver;
                            driver = new Entities.Person();                            
                        }                           

                        if (driver.JobType == Enums.JobType.Piloto)
                            quantityPiloto++;

                        if (driver.JobType == Enums.JobType.ChefeTripulacao)
                            quantityChef++;

                        if (quantityChef >= 2 || quantityPiloto >= 3)
                        {
                            passenger = driver;
                            driver = new Entities.Person();
                        }                            
                    }
                    else continue;
                }
                else continue;                
            }
            return new
            {
                peopleBoarded = personBording,
                listWrite = listString
            };            
        }
    }
}
