using CodeIt.Business.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodeIt.Business.Entities
{
    public class Person
    {
        public string Name { get; set; }
        public JobType JobType { get; set; }
        public bool drive { 
            get => isDriver(JobType);
        }

        public bool isDriver (JobType job)
        {
            if (job == JobType.Piloto || job == JobType.Policial || job == JobType.ChefeTripulacao) return true;
            return false;
        }
    }
    
}
