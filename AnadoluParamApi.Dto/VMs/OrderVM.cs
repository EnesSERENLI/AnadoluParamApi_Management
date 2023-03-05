using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnadoluParamApi.Dto.VMs
{
    public class OrderVM
    {
        public string ProductName { get; set; }
        public short Quantity { get; set; }
        public string UnitType { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
