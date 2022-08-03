using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using static ConsoleApp.ISkvazhAndPlace;

namespace ConsoleApp.Functions
{
    class SkvazhAndPlace : ISkvazhAndPlace
    {
            //        3.	Выводит на консоль название скважины и её принадлежность к месторождению.В формате: 
            //<Название_месторождения>: <список_названий_скважин>.
        public  void FindPlaceWell()
        {
            List<Departments> departmentsItems;
            List<WellSctructss> wellStructItems;

            // Чтение данных из обоих словарей
            #region Read departments.json and massiv
            using (StreamReader r = new StreamReader("departments.json"))
            {
                // Чтение файла и опрокидывание в лист
                string json = r.ReadToEnd();
                departmentsItems = JsonConvert.DeserializeObject<List<Departments>>(json);
            }
            #endregion

            #region Read departments.json and massiv
            using (StreamReader r = new StreamReader("wells.json"))
            {
                // Чтение файла и опрокидывание в лист
                string json = r.ReadToEnd();
                try
                {
                    wellStructItems = JsonConvert.DeserializeObject<List<WellSctructss>>(json);

                    #region Обработка данных
                    Console.WriteLine("");
                    Console.WriteLine("Список принадлежащих месторождений:");


                    for (int i = 0; i < departmentsItems.Count; i++)
                    {
                        for (int j = 0; j < wellStructItems.Count; j++)
                        {
                            double x_count_max = departmentsItems[i].X + departmentsItems[i].Radius;
                            double y_count_max = departmentsItems[i].Y + departmentsItems[i].Radius;
                            double x_count_min = departmentsItems[i].X;
                            double y_count_min = departmentsItems[i].Y;


                            if (wellStructItems[j].X != null || wellStructItems[j].Y != null)
                            {
                                if (x_count_min < Convert.ToDouble(wellStructItems[j].X)  &&
                                    Convert.ToDouble(wellStructItems[j].X) < x_count_max &&
                                    y_count_min < Convert.ToDouble(wellStructItems[j].Y) &&
                                    Convert.ToDouble(wellStructItems[j].Y) < y_count_max)
                                {
                                    Console.WriteLine(departmentsItems[i].Name + " - " + wellStructItems[j].Name);
                                }
                            }
                            else
                            {
                                
                            }
                            
                        }



                    }
                    for (int i = 0; i < wellStructItems.Count; i++)
                    {
                        if (wellStructItems[i].X == null || wellStructItems[i].Y == null)
                        {
                            Console.WriteLine( "Неизвестное месторождение - " + wellStructItems[i].Name);
                        }
                    }
                    #endregion








                }
                catch (Newtonsoft.Json.JsonSerializationException ex)
                {

                     Console.WriteLine(ex.Message);
                }
                
            }
            #endregion

           





        }

    }

}
