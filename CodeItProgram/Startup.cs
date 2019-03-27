using CodeIt.Business.Business;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CodeItProgram
{
    public class Startup
    {
        private static Boarding boarding;

        public Startup()
        {
            boarding = new Boarding();
        }

        public List<string> simpleProcess()
        {
            return boarding.applyRules();
        }
        public List<string> complexProcess(dynamic rangeOfPeople)
        {
            return boarding.applyRules(rangeOfPeople);
        }

        public dynamic genereteInputConsole()
        {
            var rangeTripulation = new List<dynamic>();
            Console.WriteLine("---------- VAMOS COMECAR A INCLUIR A TRIPULACAO ----------");

            Console.WriteLine("Digite o nome do POLICIAL: ");
            rangeTripulation.Add(new
            {
                Name = Console.ReadLine(),
                JobType = 5
            });
            Console.WriteLine("Digite o nome do PRESIDIARIO: ");
            rangeTripulation.Add(new
            {
                Name = Console.ReadLine(),
                JobType = 6
            });
            Console.WriteLine("Digite o nome do PILOTO: ");
            rangeTripulation.Add(new
            {
                Name = Console.ReadLine(),
                JobType = 1
            });

            Console.WriteLine("Digite o nome do primeiro OFICIAL: ");
            rangeTripulation.Add(new
            {
                Name = Console.ReadLine(),
                JobType = 3
            });

            Console.WriteLine("Digite o nome do segundo OFICIAL: ");
            rangeTripulation.Add(new
            {
                Name = Console.ReadLine(),
                JobType = 3
            });

            Console.WriteLine("Digite o nome CHEFE DE BORDO: ");
            rangeTripulation.Add(new
            {
                Name = Console.ReadLine(),
                JobType = 2
            });

            Console.WriteLine("Digite o nome da primeira COMISSARIA: ");
            rangeTripulation.Add(new
            {
                Name = Console.ReadLine(),
                JobType = 4
            });

            Console.WriteLine("Digite o nome da segunda COMISSARIA: ");
            rangeTripulation.Add(new
            {
                Name = Console.ReadLine(),
                JobType = 4
            });
            return rangeTripulation;
        }

        public string exportFile(List<string> lines)
        {
            string folder = @"C:\Temp";
            if (!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
            }
            string fileName = $@"{folder}\Boarding.txt";
            try
            {
                if (File.Exists(fileName))
                {
                    File.Delete(fileName);
                }
                // Create a new file     
                using (FileStream fs = File.Create(fileName))
                {
                    foreach (var line in lines)
                    {
                        Byte[] lineWrite = new UTF8Encoding(true).GetBytes(line);
                        fs.Write(lineWrite);
                    }
                }
            }
            catch (Exception Ex)
            {
                Console.WriteLine(Ex.ToString());
                return null;
            }
            return fileName;
        }
    }
}
