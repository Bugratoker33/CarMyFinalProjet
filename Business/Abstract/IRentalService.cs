using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IRentalService
    {
        IResults Add(Rental rental);
        IDataResult<Rental> GetByRentalId(int id);
        IDataResult<List<Rental>> GetAll();

        IDataResult<Rental> GetById(int rental);
        IResults Delete(Rental rental);
        IResults Update(Rental rental);
        IDataResult<List<RentDetailDto>> GetDetails();
    }
}
