using Erp.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Erp.Business.Catalog.CustomerBusiness
{
    public interface ICustomerBusiness
    {
        Task<List<Customer>> GetListCustomer();
    }
}
