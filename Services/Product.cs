using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Services
{
    public class Product
    {
        public required string  ID    { get; set; }
        public required string  Desc  { get; set; }
        public required int     Qty   { get; set; }
        public required decimal ProductValue { get; set; }
    }
}
