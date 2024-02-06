using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete 
{ // CAR MANEGER NEWLENİĞİNDE BANA BİR ICARDL REFERANSI VER VE I CAR DALIN METHODLARINI KULANABİLEYİM
    public class CarManeger : ICarService
    {
        ICarDal _carDal;

        public CarManeger(ICarDal carDal)
        {

          _carDal = carDal;

        }
      //  [SecuredOperation("car.add,admin")]
        [ValidationAspect(typeof(CarValidation))]
        [CacheRemoveAspect("ICarService.Get")]
        public IResults Add(Car car)
        {

            //ValidationTool.Validate(new CarValidation()  ,car);

            //var context=new ValidationContext<Car>(car);
            //CarValidation  carValidator= new CarValidation();
            //var result= carValidator.Validate(context);
            //if (!result.IsValid)
            //{
            //    throw new ValidationException(result.Errors);
            //}
            //businos kodları yazılı 
            //if (car.Descriptions.Length > 2 && car.DailPrice > 0)
            //{
            //    _carDal.Add(car);
            //}
            //else
            //{
            //    Console.WriteLine("EROR!!!!!!");
            //}
            _carDal.Add(car);
            return new SuccessResult (Messages.CarAdded);
        }

        public IResults Delete(Car car)
        {
             _carDal.Delete(car);
            return new SuccessResult(Messages.CarDelete);
        }
        [CacheAspect]
        public IDataResult< List<Car>> GetAll()
        {
          return  new SuccsessDataResult<List<Car>>(_carDal.GetAll(),Messages.CartsListed);

        }
        [CacheAspect]
        public IDataResult<Car> GetById(int carId)
        {
            return new SuccsessDataResult<Car>(_carDal.Get(p => p.Id == carId), Messages.CartsListed);
           
        }

        public IDataResult<List<CarDetailDto>> GetCarDetail()
        {
            if (DateTime.Now.Hour==3)
            {
                return new ErrorDataResult<List<CarDetailDto>>(Messages.MaintenanceTime);
            }
           return new SuccsessDataResult<List<CarDetailDto>>( _carDal.GetCarDetail(),Messages.CartsListed);
        }

        public IDataResult<List<Car>> GetCarsByBrandId(int id)
        {
            return new SuccsessDataResult<List<Car>> (_carDal.GetAll(p => p.BrandId == id), Messages.CartsListed);
        }

      
        public IDataResult<List<Car>> GetCarsByDailPrice(decimal min, decimal max)
        {
            return new SuccsessDataResult<List<Car>>( _carDal.GetAll(p => p.DailPrice >= min && p.DailPrice <= max));
        }
        [CacheRemoveAspect("ICarService.Get")]
        public IResults Update(Car car)
        {
           _carDal.Update(car);
            return new SuccessResult(Messages.CarUpdate);
        }

    }
}
