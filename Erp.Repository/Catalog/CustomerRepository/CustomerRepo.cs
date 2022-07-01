using Erp.Model.Entities;
using Erp.Model.EntityFramework;
using Erp.Repository.Catalog.BaseRepository;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Erp.Repository.Catalog.CustomerRepository
{
    public class CustomerRepo : BaseRepository<Customer, int, Solution_30ShineContext>, ICustomerRepo
    {
        private readonly Solution_30ShineContext _dbContext;
        public CustomerRepo(Solution_30ShineContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
