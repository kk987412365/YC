using System.Collections.Generic;
using System.Web.Http;
using YC.Models;

namespace YC.Controllers
{
    public class CurdController : ApiController
    {
        [HttpPut]
        [Route("curd/insertCustomer")]
        public string InsertCustomer(Customer data)
        {
            return Customer.InsertFunc(data);
        }

        [HttpPost]
        [Route("curd/updateCustomerByID")]
        public string UpdateCustomerByID(Customer data)
        {
            return Customer.UpdateFunc(data);
        }

        [HttpGet]
        [Route("curd/getCustomerByID/{id}")]
        public IEnumerable<Customer> getCustomerByID(string id)
        {
            return Customer.GetCustomerByID(id);
        }


        [HttpDelete]
        [Route("curd/deleteCustomerByID/{id}")]
        public string DeleteCustomerByID(string id)
        {
            return Customer.DeleteCustomerByID(id);
        }

 
    }
}