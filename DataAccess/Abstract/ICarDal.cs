using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface ICarDal:IEntityRepository<Car>
    {//ı car da entitityrepositorinin methodlarını kulanabileyimder
        //ı car dal ayrıca efcardalın referansına tutabilir 
        List<CarDetailDto> GetCarDetail();

    }
}
