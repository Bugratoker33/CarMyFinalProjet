using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICustomerService
    {
        IResults Add(Customer customer);
        IDataResult<Customer> GetByCustomerId(int id);
        IDataResult<List<Customer>> GetAll();
       
        IDataResult<Customer> GetById(int custumer);
        IResults Delete(Customer customer);
        IResults Update(Customer customer);
    }
}
