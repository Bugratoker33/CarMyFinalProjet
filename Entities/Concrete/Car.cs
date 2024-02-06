using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Car:IEntity
    {
        public int Id { get; set; }
        public int BrandId { get; set; }
        public int ClorId { get; set; }
        public int ModelYear { get; set; }
        public decimal DailPrice { get; set; }
        public string Descriptions { get; set; }
        //car name sil ama dail price günlük aylık olarak farklı ayarla 


    }
}
