using System;
using ConsoleApp.Functions;


namespace ConsoleApp
{
    class Program
    {
        static Program mainApp = new Program();

        static void Main(string[] args)
        {
            
            mainApp.MainProcedure();

        }

        /// <summary>
        /// Процедурка основного текста приложения
        /// </summary>
        public void BeginnerWriteLine()
        {
            Console.WriteLine("Меню выборки функциональной команды");
            Console.WriteLine("1 - Вывод параметров и скважин ");
            Console.WriteLine("2 - Выборка скважин с 10 по 30 и их показателей ");
            Console.WriteLine("3 - Вывод скважин и их принадлежности месторождениям ");
            Console.WriteLine("Введите цифру команды, которую хотите использовать: ");
        }

        public void MainProcedure()
        {
            // Накидать выборку, от выборки будет зависеть каждая отдельная задача. Накидать по задачам отдельные библиотеки для дальнейшего сопровождения.
            // Например, разделение по функционалу для удобства сопровождения. По основной задаче будет 1,2,3 библиотеки с различным API. Желательно реализовать через интерфейсы.
            Program mainProgr = new Program();

            mainProgr.BeginnerWriteLine();

            string name = Console.ReadLine();
            if (name.Length == 1 && name.Contains("1"))
            {
                UnicWellParametersClass unicWellParameters = new UnicWellParametersClass();
                unicWellParameters.OutUnicParametrs();
            }
            else if (name.Length == 1 && name.Contains("2"))
            {
                SkvazhinAndParameters SAP = new SkvazhinAndParameters();
                SAP.OutSkvazh();
            }
            else if (name.Length == 1 && name.Contains("3"))
            {
                SkvazhAndPlace SAP = new SkvazhAndPlace();
                SAP.FindPlaceWell();
            }

            Console.WriteLine("____________________");
            mainApp.MainProcedure();

        }
       
    }
}
