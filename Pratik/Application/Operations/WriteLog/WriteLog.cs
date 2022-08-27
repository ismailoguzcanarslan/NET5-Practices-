using Pratik.DbCntxt;
using Pratik.Entities;

namespace Pratik.Application.Operations.WriteLog
{
    public class WriteLog
    {
        private readonly BookStoreDbContext _bookStoreDbContext;
        private readonly Log _log;

        public WriteLog(BookStoreDbContext bookStoreDbContext, Log log)
        {
            _bookStoreDbContext = bookStoreDbContext;
            _log = log;
        }

        public void Handle()
        {
            _bookStoreDbContext.Add(_log);
            _bookStoreDbContext.SaveChanges();
        }
    }
}
