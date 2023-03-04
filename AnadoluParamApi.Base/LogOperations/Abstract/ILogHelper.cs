using AnadoluParamApi.Base.LogOperations.Concrete;

namespace AnadoluParamApi.Base.LogOperations.Abstract
{
    public interface ILogHelper
    {
        MongoDB_Log CreateLog(string controllerName,string methodName, string stackTrace, string errorDescription, string personalDescription);
        void InsertLogDetails(MongoDB_Log log);
    }
}
