using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ConsoleApp.Functions
{
    class SkvazhinAndParameters : ISkvazhinAndParameters
    {
        //2.	Для скважин с id от 10 до 30 выводит на консоль название скважины, а также название и минимальное, максимальное, среднее арифметическое и медианное значения каждого параметра с округление до 2х знаков, если по нему имеется хоть 1 значение в wellParameters.json в формате:
        //<Название_скважины>
        //1. <Название параметра_1>: min - <знач.>, max - <знач.>, ave - <знач.>, med - <знач.> 
        //и т.д.

        public void OutSkvazh()
        {
            List<WellSctruct> wellItems;
            List<WellParamSctruct> wellParamItems;


            // Чтение данных из обоих словарей
            #region Read wells.json and massiv
            using (StreamReader r = new StreamReader("wells.json"))
            {
                // Чтение файла и опрокидывание в лист
                string json = r.ReadToEnd();
                wellItems = JsonConvert.DeserializeObject<List<WellSctruct>>(json);
            }
            #endregion

            #region Read wellParameters.json and massiv
            using (StreamReader r = new StreamReader("wellParameters.json"))
            {
                // Чтение файла и опрокидывание в лист
                string json = r.ReadToEnd();
                wellParamItems = JsonConvert.DeserializeObject<List<WellParamSctruct>>(json);
            }
            #endregion

            // Вывод данных по ид из одного. Нужно ли пихать в отдельный массив или сразу работать на вывод для удобства.Может, запилить перекрёстный массив?
            for (int i = 0; i < wellItems.Count; i++)
            {
                if (wellItems[i].Id >= 10 && wellItems[i].Id <= 30)
                {
                    OutSkvazhName(wellItems[i].Id, wellItems[i].Name);
                    FindParameters(wellItems[i].Id, wellParamItems);
                }


            }



        }
        private void OutSkvazhName(int idd, string strOut_1)
        {
            Console.WriteLine(Convert.ToString(idd) + ", " + strOut_1 + ": ");
        }
        private void OutSkvazhName(string strOut_1, double strOut_2)
        {
            Console.WriteLine(strOut_1 + "= " + strOut_2);
        }

        /// <summary>
        /// Работа с параметрами
        /// </summary>
        /// <param name="idd">id скважины для нахождения параметров</param>
        /// <param name="mas">Общий словарь параметров по скважинам</param>
        private void FindParameters(int idd, List<WellParamSctruct> mas)
        {
            Param(idd, mas, "Дебит жидкости");
            Param(idd, mas, "Дебит нефти");
            Param(idd, mas, "Динамический уровень");
            Param(idd, mas, "Частота двигателя");
            Param(idd, mas, "Температура двигателя");
            Param(idd, mas, "Напряжение трансформатора");
            Param(idd, mas, "Ток двигателя");
            Param(idd, mas, "Плотность нефти");
            Param(idd, mas, "Вязкость нефти");
            Param(idd, mas, "Давление на приеме");
        }


        public void Param(int idd, List<WellParamSctruct> mas,  string paramName)
        {
            
            double[] minValue = new double[mas.Count];
            double min = 0;
            double max = 0;
            double AVR = 0;
            int count_minValue = 0;

            int z_count = 0;

            Console.Write(paramName + "-");
            for (int i = 0; i < mas.Count; i++)
            {
                if (mas[i].WellId == idd && mas[i].ParameterName.Contains(paramName))
                {
                    // Работа с параметрами конкретной скважины!!!!!                  

                    minValue[z_count] = mas[i].Value;

                    z_count = z_count + 1;

                }
            }

            #region Минимальное
            // Минимальное
            min = minValue[0];
            for (int a = 0; a < minValue.Length && minValue[a] != 0; a++)
            {
                if (min > minValue[a])
                {
                    min = minValue[a];
                }
            }
            Console.Write(" Минимальное - " + min);
            #endregion

            #region Максимальное
            // Максимальное
            max = minValue[0];
            for (int a = 0; a < minValue.Length && minValue[a] != 0; a++)
            {
                if (max < minValue[a])
                {
                    max = minValue[a];
                }
            }
            Console.Write(" Максимальное - " + max);
            #endregion

            #region Среднее
            // Среднее арифм
            AVR = minValue[0];
            count_minValue = 0;
            for (int a = 0; a < minValue.Length && minValue[a] != 0; a++)
            {
                AVR = AVR + minValue[0];
                count_minValue = count_minValue + 1;
            }
            AVR = AVR / count_minValue;
            Console.WriteLine(" Среднее - " + AVR);
            #endregion

        }
    }
}

