using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ConsoleApp.Functions
{

    class UnicWellParametersClass: IUnicWellParameters
    {
        //1.	Выводит на консоль список названий всех уникальных параметров, встречающихся в wellParameters.json в формате:
        //Параметры:
        //1. <Название_параметра_1>
        //2. <Название_параметра_2> и т.д.
               
        public void OutUnicParametrs()
        {
            string[] masUnicParameters;

            using (StreamReader r = new StreamReader("wellParameters.json"))
            {              
                // Чтение файла и опрокидывание в лист
                string json = r.ReadToEnd();
                List<WellParametersSctruct> items = JsonConvert.DeserializeObject<List<WellParametersSctruct>>(json);
                //dynamic array = JsonConvert.DeserializeObject(json);

                // Создание обычного массива для вывода параметров из листа
                masUnicParameters = new string[items.Count]; //
                string tempStr = items[0].ParameterName;


                Console.WriteLine("");
                Console.WriteLine("Список уникальных параметров:");
                OutParam(tempStr);

                for (int i = 1; i < items.Count; i++)
                {
                    if (tempStr != items[i].ParameterName)
                    {
                        //Console.WriteLine(masUnicParameters[i]);
                        //masUnicParameters[countMas] = items[i-1].ParameterName;
                        tempStr = items[i].ParameterName;
                        OutParam(tempStr);
                    }                    
                }

                
                
                



            }            
        }

        public void OutParam(string param)
        {
            Console.WriteLine(param);
        }



    }
}
