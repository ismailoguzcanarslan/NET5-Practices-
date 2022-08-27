using Pratik.Entities;

namespace Pratik.Services
{
    public class ConsoleLogger : ILoggerService<Log>
    {
        public void Write(Log log)
        {
            System.Console.WriteLine("Log Type: " + log.LogType + ", HttpMethod: " + log.HttpMethod + ", RequestPath: " + log.Path);
        }
    }
}
