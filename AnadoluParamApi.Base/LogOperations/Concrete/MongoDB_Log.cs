namespace AnadoluParamApi.Base.LogOperations.Concrete
{
    public class MongoDB_Log
    {
        public string ControllerName { get; set; }
        public string MethodName { get; set; }
        public string StackTrace { get; set; }
        public string ErrorDescription { get; set; }
        public string PersonalDescription { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
