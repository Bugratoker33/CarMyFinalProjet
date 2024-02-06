using Core;
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class CarDetailDto:IDto
    {
        //[Id]
        //,[BrandId]
        //,[ClorId]
        //,[ModelYear]
        //,[Descriptions]
        //,[DailPrice]
        public int Id { get; set; }
        public string BrandName { get; set; }
        public string ClorName { get; set; }
        public int ModelYear { get; set; }
        public decimal DailPrice { get; set; }
        public string Descriptions { get; set; }

    }
}
