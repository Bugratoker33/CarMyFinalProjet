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
    public class BrandManeger : IBrandService
    {
        IBrandDal _brandal;
        public BrandManeger(IBrandDal brandDal)
        {
            _brandal = brandDal;
        }
        [ValidationAspect(typeof(BrandValidation))]
        public IResults Add(Brand brand)
        {
          _brandal.Add(brand);
            return new SuccessResult(Messages.CarAdded);
        }

        public IResults Delete(Brand brand)
        {
          _brandal.Delete(brand);
            return new SuccessResult(Messages.CarDelete);
        }

        public IDataResult <List<Brand> >GetAll()
        {
            return new SuccsessDataResult<List<Brand>> (_brandal.GetAll(),Messages.CartsListed);
        }

        public IDataResult <List<Brand>> GetByBrandId(int id)
        {
            return new SuccsessDataResult<List<Brand>> ( _brandal.GetAll(c => c.BrandId == id));
        }

        public IDataResult<Brand> GetById(int brandıd)
        {
            return new SuccsessDataResult<Brand>(_brandal.Get(p => p.BrandId == brandıd),Messages.CartsListed);
        }

        public IResults Update(Brand brand)
        {
           _brandal.Update(brand);
            return new SuccessResult(Messages.CarUpdate);
        }
    }
}
