using Erp.Business.Catalog.CustomerBusiness;
using Erp.Repository.Catalog.CustomerRepository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Erp.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/customer")]
    public class CustomerController : Controller
    {
        private readonly ICustomerBusiness _customerBusiness;
        public CustomerController(ICustomerBusiness customerBusiness)
        {
            _customerBusiness = customerBusiness;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllStaff()
        {
            try
            {
                var result = await _customerBusiness.GetListCustomer();
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
