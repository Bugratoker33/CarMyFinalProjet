using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CustumerManeger : ICustomerService
    {
        ICostomer _costomer;
        public CustumerManeger(ICostomer costomerdal)
        {
            _costomer = costomerdal;
        }
        [ValidationAspect(typeof(CustomerValidation))]
        public IResults Add(Customer customer)
        {
          _costomer.Add(customer);
            return new SuccessResult(Messages.CarAdded);
        }

        public IResults Delete(Customer customer)
        {
            _costomer.Delete(customer);
            return new SuccessResult(Messages.CarDelete);
        }

        public IDataResult<List<Customer>> GetAll()
        {
            return new SuccsessDataResult<List<Customer>>(_costomer.GetAll(),Messages.CartsListed);
        }

        public IDataResult<Customer> GetByCustomerId(int id)
        {
            return new SuccsessDataResult<Customer>(_costomer.Get(p => p.CustomerId == id),Messages.CartsListed );
        }

        public IDataResult<Customer> GetById(int custumer)
        {
            return new SuccsessDataResult<Customer>(_costomer.Get(g => g.CustomerId == custumer),Messages.CartsListed);
        }

        public IResults Update(Customer customer)
        {
           _costomer.Update(customer);
            return new SuccessResult(Messages.CarUpdate);
        }
    }
}
