using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradingAppData.Repository;
using TradingAppData.Datamodel;

namespace TradingAppData.Uow
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<Customer> CustomerRepository     { get; }

        void Save();
    }
}
