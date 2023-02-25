using AnadoluParamApi.Base.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnadoluParamApi.Data.Model
{
    public class Order : BaseModel
    {
        public int AccountId { get; set; }
        public virtual Account Account { get; set; }
        public virtual List<OrderDetail> OrderDetails { get; set; }

    }
}
