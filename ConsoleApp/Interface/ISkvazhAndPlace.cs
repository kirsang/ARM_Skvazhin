using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp
{
    interface ISkvazhAndPlace
    {
        public class Departments
        {
            public string Name { get; set; }
            public double X { get; set; }
            public double Y { get; set; }
            public double Radius { get; set; }
        }

        public class WellSctructss
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public object X { get; set; }
            public object Y { get; set; }
        }




        public void FindPlaceWell();
    }
}
