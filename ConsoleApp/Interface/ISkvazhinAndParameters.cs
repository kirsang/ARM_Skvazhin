using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp
{
    /// <summary>
    /// Класс-структура json-файла WellParameters
    /// </summary>
    public class WellParamSctruct
    {
        /// <summary>
        /// Класс-структура json-файла Wells
        /// </summary>
        public int WellId { get; set; }
        public string ParameterName { get; set; }
        public double Value { get; set; }
    }

    /// <summary>
    /// Класс-структура json-файла WellParameters
    /// </summary>
    public class WellSctruct
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public object X { get; set; }
        public object Y { get; set; }
    }

    interface ISkvazhinAndParameters
    {
        //Чистый вход без данных

        /// <summary>
        /// Функция вывода параметров со скважин с ид с 10 по 30 
        /// </summary>
        /// <returns>Уникальные параметры списком</returns>
        public void OutSkvazh();

    }
}
