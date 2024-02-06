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
    public interface ICarService
    {
       IDataResult< List<Car>> GetAll();

       IDataResult< List<Car>> GetCarsByBrandId(int id);
       IDataResult< List<Car>> GetCarsByDailPrice(decimal min, decimal max);

        IResults Add(Car car);
        IResults Update(Car car);
        IResults Delete(Car car);
        IDataResult<Car> GetById(int CarId);
        IDataResult<List<CarDetailDto>> GetCarDetail();

    }
}
