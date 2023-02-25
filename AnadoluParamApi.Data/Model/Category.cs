using AnadoluParamApi.Base.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnadoluParamApi.Data.Model
{
    public class Category : BaseModel
    {
        public string CategoryName { get; set; }
        public string Description { get; set; }

        //Relation Properties

        public virtual List<SubCategory> SubCategories { get; set; }
    }
}
