using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Car
    {
        public int id { get; set; }

        public CarModel carModel { get; set; }
        public int carModelId { get; set; }

        public int year { get; set; }

    }
}
