using Erp.Model.Entities;
using Erp.Model.EntityFramework;
using Erp.Repository.Catalog.BaseRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Erp.Repository.Catalog.CustomerRepository
{
    public interface ICustomerRepo : IBaseRepository<Customer, int, Solution_30ShineContext>
    {
    }
}
