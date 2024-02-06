using Core.DataAccess.EntityFramework;
using Core.Entities;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, RentACarContext>, ICarDal
    //ef entity repository veri tabanı işlemleri için ,ı car dal sa arabanın detayını görmek istiyorum o zaman ı car dala methode yazarız çünkü ı car dal bir interface ve burda uygularız
    //car tablosuna join atmak gibi detaylı görmek istiyorsak heryerde join yazmıyoruz gideriz ıcar dalın içine yazarız

    {
        public List<CarDetailDto> GetCarDetail()
        {//[Id]
         //,[BrandId]name
         //,[ClorId]name
         //,[ModelYear]
         //,[Descriptions]
         //,[DailPrice]
            using (RentACarContext carContext = new RentACarContext())
            {
                var result= from c in carContext.Car
                    join b in carContext.Brand
                    on c.BrandId equals b.BrandId
                    join  r in carContext.Colour
                    on c.ClorId equals r.ColourId
                    select new CarDetailDto {Id = c.Id , BrandName=b.BrandName,ClorName=r.ColourName ,ModelYear=c.ModelYear ,Descriptions=c.Descriptions , DailPrice=c.DailPrice };
                return result.ToList();

            }
        
        }
    }
}
