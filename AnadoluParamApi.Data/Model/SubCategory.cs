using AnadoluParamApi.Base.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnadoluParamApi.Data.Model
{
    public class SubCategory : BaseModel
    {
        public string SubCategoryName { get; set; }
        public string Description { get; set; }

        //Relations
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
        public virtual List<Product> Products { get; set; }
    }
}
