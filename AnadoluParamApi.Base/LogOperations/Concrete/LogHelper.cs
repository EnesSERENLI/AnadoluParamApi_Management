using AnadoluParamApi.Base.LogOperations.Abstract;
using MongoDB.Driver;

namespace AnadoluParamApi.Base.LogOperations.Concrete
{
    public class LogHelper : ILogHelper
    {
        private readonly IMongoDatabase mongoDb;
        public LogHelper(IMongoDatabase mongoDb)
        {
            this.mongoDb = mongoDb;
        }

        public MongoDB_Log CreateLog(string controllerName, string methodName, string stackTrace, string errorDescription, string personalDescription)
        {
            MongoDB_Log log = new MongoDB_Log();
            log.ControllerName = controllerName;
            log.MethodName = methodName;
            log.StackTrace = stackTrace;
            log.ErrorDescription = errorDescription;
            log.PersonalDescription = personalDescription;
            log.CreatedDate = DateTime.Now;
            return log;
        }

        public void InsertLogDetails(MongoDB_Log log)
        {
            var collection = mongoDb.GetCollection<MongoDB_Log>("AnadoluPrmLogs");
            collection.InsertOne(log);
        }

    }
}
