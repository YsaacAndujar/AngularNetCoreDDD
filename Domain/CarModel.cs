using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class CarModel
    {
        public int id { get; set; }

        public Brand brand { get; set; }

        public int brandId { get; set; }

        public string name { get; set; }
    }
}
