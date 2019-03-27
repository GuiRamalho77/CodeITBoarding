using System;
using System.Collections.Generic;
using System.Text;

namespace CodeIt.Business.Helpers
{
    public static class LogHelper
    {
        public static Entities.Log saveLog(bool valid, Entities.Person driver, Entities.Person passenger)
        {
            
            return new Entities.Log
            {
                Message = $"A viagem ate o aviao com o SmartForTo foi dirigido pelo {driver.JobType} {driver.Name.ToUpper()}, " +
                    $"eo PASSAGEIRO foi o {passenger.JobType} {passenger.Name.ToUpper()}" +
                    $" O {passenger.Name.ToUpper()} ficou no aviao e o {driver.Name.ToUpper()} voltou dirigindo para o embarque.",
                isValid = valid
            };
            return null;
        }
    }
}
