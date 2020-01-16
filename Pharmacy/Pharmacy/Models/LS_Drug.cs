using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharmacy.Models
{
    class LS_Drug
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? Count { get; set; }
        public decimal? Price { get; set; }

        public override string ToString()
        {
            return $"{Name}-{Count}";
        }
    }
}
