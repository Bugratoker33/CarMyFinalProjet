using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class RentalManeger : IRentalService
    {

        IRental _rental;
        public RentalManeger(IRental rentaldal)
        {
            _rental = rentaldal;

        }
        public IResults Add(Rental rental)
        {
            _rental.Add(rental);
            return new SuccessResult(Messages.CarAdded);
        }

        public IResults Delete(Rental rental)
        {
            _rental.Delete(rental);
            return new SuccessResult();
        }

        public IDataResult<List<Rental>> GetAll()
        {
         return new SuccsessDataResult<List<Rental>>(_rental.GetAll(), Messages.CartsListed);
        }

        public IDataResult<Rental> GetById(int rental)
        {
            return new SuccsessDataResult<Rental>(_rental.Get(r => r.RentalId == rental),Messages.CartsListed);
        }

        public IDataResult<Rental> GetByRentalId(int id)
        {
            return new SuccsessDataResult<Rental>(_rental.Get( p => p.RentalId == id),Messages.CartsListed);
        }

        public IDataResult<List<RentDetailDto>> GetDetails()
        {
            return new SuccsessDataResult<List<RentDetailDto>>(_rental.GetRentDetailDtos());
        }

        public IResults Update(Rental rental)
        {
            return new SuccessResult();
        }
    }
}
