using Erp.Model.Entities;
using Erp.Repository.Catalog.CustomerRepository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Erp.Business.Catalog.CustomerBusiness
{
    public class CustomerBusiness : ICustomerBusiness
    {
        private readonly ICustomerRepo _customerRepo;
        public CustomerBusiness(ICustomerRepo customerRepo)
        {
            _customerRepo = customerRepo;
        }

        public async Task<List<Customer>> GetListCustomer()
        {
            var result = await _customerRepo.GetList(x => x.IsDelete.Value == 1);
            return result;
        }
    }
}
