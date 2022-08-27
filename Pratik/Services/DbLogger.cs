using Pratik.DbCntxt;
using Microsoft.Extensions.DependencyInjection;
using System;
using Microsoft.EntityFrameworkCore;
using Pratik.Entities;
using Pratik.Application.Operations.WriteLog;

namespace Pratik.Services
{
    public class DbLogger : ILoggerService<Log>
    {
        private readonly BookStoreDbContext _bookStoreDbContext;

        public DbLogger(BookStoreDbContext bookStoreDbContext)
        {
            _bookStoreDbContext = bookStoreDbContext;
        }
                  
        public void Write(Log log)
        {
            WriteLog writeLog = new WriteLog(_bookStoreDbContext, log);
            writeLog.Handle();
        }
    }
}
