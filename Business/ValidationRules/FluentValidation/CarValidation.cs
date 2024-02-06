using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class CarValidation : AbstractValidator<Car>
    {//data transfer object
        // veri aktarım nesnesi 
        //abtaracvalidator==
        public CarValidation()
        {
            RuleFor(p => p.Descriptions).NotEmpty();//ismi boş olamaz
            RuleFor(p => p.Descriptions).MinimumLength(2);
            RuleFor(p => p.DailPrice).NotEmpty();
            RuleFor(p => p.DailPrice).GreaterThan(0);
          //  RuleFor(p => p.DailPrice).GreaterThanOrEqualTo(10).When(p => p.BrandId == 1);//BRAND ID BMW İSE
            //ctr k,d 
            //dağınık kodları düzeltir 

            //olmayan kuraları kendimiz yazma yöntemi
            RuleFor(p => p.Descriptions).Must(StartWithA).WithMessage("ürünler A harfi ile başlamalıdır");


        }

        private bool StartWithA(string arg)
        {
            return arg.StartsWith("A");
        }
    }
    
}
