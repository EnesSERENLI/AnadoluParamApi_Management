using AnadoluParamApi.Base.Model;

namespace AnadoluParamApi.Data.Model
{
    public class Product : BaseModel
    {
        public string ProductName { get; set; }
        public string Description { get; set; }
        public decimal UnitPrice { get; set; }
        public short UnitsInStock { get; set; }
        public string UnitType { get; set; }

        //Relations
        public int SubCategoryId { get; set; }
        public virtual SubCategory SubCategory { get; set; }
        public virtual List<OrderDetail> OrderDetails { get; set; }
    }
}
