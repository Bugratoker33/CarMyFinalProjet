using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, RentACarContext>, IRental
    {
        public List<RentDetailDto> GetRentDetailDtos()
        {
            using (RentACarContext context = new RentACarContext())
            {
                var result = from r in context.Rental
                             join b in context.Brand
                             on r.CarId equals b.BrandId
                             join u in context.User
                             on r.CustomerId equals u.UserId
                            
                             select new RentDetailDto
                             {
                                 CarId = b.BrandName,
                                 CustomerId = u.FirstName +"---"+ u.LastName,
                                 RentDate = r.RentDate,
                                 Price = r.Price,



                             };
                return result.ToList();


            }
        }
    }
    
}
