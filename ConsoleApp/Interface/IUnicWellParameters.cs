using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp
{

    /// <summary>
    /// Класс-структура json-файла WellParameters
    /// </summary>
    public class WellParametersSctruct
    {
        public int WellId { get; set; }
        public string ParameterName { get; set; }
        public float Value { get; set; }
    }


    /// <summary>
    /// Интерфейс реализации списка названий уник параметров
    /// </summary>
    interface IUnicWellParameters
    {
        //На вход ничего не надо, нужно просто выводить параметры и отправлять в основу проги

        /// <summary>
        /// Функция вывода уникальный параметров
        /// </summary>
        /// <returns>Уникальные параметры списком</returns>
        public void OutUnicParametrs();


    }
}
