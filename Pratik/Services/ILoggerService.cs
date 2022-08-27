using Pratik.Entities;

namespace Pratik.Services
{
    public interface ILoggerService<T> where T : Log
    {
        public void Write(T log);
    }
}
