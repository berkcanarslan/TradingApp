using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradingAppData.Context;
using TradingAppData.Repository;
using TradingAppData.Datamodel;
using Microsoft.Extensions.Configuration;

namespace TradingAppData.Uow
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IConfiguration configuration;
        private readonly TradingDbContext context;
        private readonly ILogger logger;
        public IGenericRepository<Customer> CustomerRepository { get; private set; }

        public UnitOfWork(TradingDbContext _context, ILoggerFactory _logger, IConfiguration _config)
        {
            context = _context;
            logger = _logger.CreateLogger("Log");
            configuration = _config;


            CustomerRepository = new GenericRepository<Customer>(context, logger);
        }


        public void Save()
        {
            context.SaveChanges();
        }

        public void Dispose()
        {
            context.Dispose();
        }

    }
}