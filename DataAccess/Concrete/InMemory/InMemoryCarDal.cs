using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;

        public InMemoryCarDal()
        {
            _cars = new List<Car> {

                new Car{Id=1,ClorId=1,  BrandId=1,DailPrice=800,Descriptions="HASARSIZ ARABA",ModelYear=2021,},
                  new Car{Id=2,ClorId=2,  BrandId=2,DailPrice=800,Descriptions="HASARSIZ ARABA",ModelYear=2021},
                    new Car{Id=3,ClorId=1, BrandId=3,DailPrice=500,Descriptions="HASARSIZ ARABA",ModelYear=2021},
                      new Car{Id=4,ClorId=3,  BrandId=1,DailPrice=20,Descriptions="HASARSIZ ARABA",ModelYear=2021},
                        new Car{Id=5,ClorId=1, BrandId=2,DailPrice=500,Descriptions="HASARSIZ ARABA",ModelYear=2021},


            };

        }

        public void Add(Car car)
        {
            _cars.Add(car);

        }

        public void Delete(Car car)
        {
            Car DeleteCar = _cars.FirstOrDefault(p => p.Id == car.Id);
            _cars.Remove(DeleteCar);

        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetById(int CarId)
        {
            return _cars.Where(p => p.Id == CarId).ToList();
        }

        public List<CarDetailDto> GetCarDetail()
        {
            throw new NotImplementedException();
        }

        public void Update(Car car)
        {
            Car UpdateCar = _cars.FirstOrDefault(p => p.Id == car.Id);

            UpdateCar.Id = car.Id;
            UpdateCar.BrandId = car.BrandId;
            UpdateCar.ClorId = car.ClorId;

        }
    }
}
