using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IBrandService
    {
        //GetAll, GetById, Insert, Update, Delete.

        IDataResult <List<Brand>> GetAll();

        IDataResult <List<Brand>> GetByBrandId(int id);

        IDataResult<Brand> GetById(int brandıd);

        IResults Add(Brand brand);
        IResults Update(Brand brand);
        IResults Delete(Brand brand);


    }
}
