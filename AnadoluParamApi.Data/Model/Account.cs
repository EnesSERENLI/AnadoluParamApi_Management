using AnadoluParamApi.Base.Model;

namespace AnadoluParamApi.Data.Model
{
    public class Account : BaseModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
        public string Role { get; set; }
        public DateTime LastActivity { get; set; }

        //Relation Property
        public virtual List<Order> Orders { get; set; }
    }
}
