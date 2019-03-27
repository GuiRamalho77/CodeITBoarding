using System;
using System.Collections.Generic;

namespace CodeItProgram
{
    class Program
    {
        static void Main(string[] args)
        {
            var startup = new Startup();
            Console.WriteLine("---------- CODEIT AIRLINES  ----------");
            Console.WriteLine(" Iniciar Aplicacao generica [1] \n Iniciar Aplicacao complexa [2]");
            int typeOfApplication = Convert.ToInt32(Console.ReadLine());

            var listConsoleWrite = new List<string>();
            switch (typeOfApplication)
            {
                case 1:
                    listConsoleWrite = startup.simpleProcess();
                    break;
                case 2:
                    listConsoleWrite = startup.complexProcess(startup.genereteInputConsole());
                    break;
            }

            foreach (var write in listConsoleWrite)
                Console.WriteLine(write);
            Console.WriteLine("DESEJA IMPORTAR O PROCESOS PARA UM ARQUIVO TXT? \n [1] SIM\n [2] NAO");
            int import = Convert.ToInt32(Console.ReadLine());
            if (import == 1)
            {
                var export = startup.exportFile(listConsoleWrite);
                if(!string.IsNullOrEmpty(export))
                Console.WriteLine("Arquivo exportado para: "+export);
            }
            Console.WriteLine("PROCESSO FINALIZADO...");
            Console.ReadLine();

        }
    }
}
