using FluentValidation;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using ValidationException = FluentValidation.ValidationException;

namespace Core.CrossCuttingConcerns.Validation
{
    //genel bir fluentvalidation yaptık 
    //ıvalidator==busnisdeki carvalidator e çünkü AbstractValidator<Car> IValidator implemte oluyor referans tutucu olarka yanı buradaki ıvalidator şimdilik carvalidator 
    public static class ValidationTool
    { //bu sınıfın amacı biz ona ı validator veriyorduz Ivalidater demek bizim ilgili methodun parametlerimizi validet etmek istediğimiz fluent validation classı yanı kuralarımızın olduğu class 
        //busnisdaki produckvalidator classına gidersek orda abstaracvalidator implemente edilmiş onun içinde ıvalidator var ı validator referance tutucudur yanıi produckvalidatordur::
        public static void Validate(IValidator validator ,object entity)//bana ıvalidator ver==carvalidator,bana ****bird varlık ver==car
        {
           
            //validator=validat edilecek class a karşılık gelir 

            var context = new ValidationContext<object>(entity);
         
            var result = validator.Validate(context);//ıvalidtorun validator methodunu validat ettik 
            if (!result.IsValid)
            {
                throw new ValidationException(result.Errors);
            }

        }
        //IValidator ProductValidator aslında ve IValidation FluentValidationdan gelir
        //doğrulamaların olduğu class -- entity ise doğrulanacak class
      //  public static void Validate(IValidator validator, object entity)
       // {
            //buradaki object için doğrulama yapcağım parametrede entity
          //  var context = new ValidationContext<object>(entity);//doğrulama işlemini gerçekleştirmesi için gerekli olan bilgileri sağlar          
          //  var result = validator.Validate(context);//doğrulama işlemini gerçekleştirir
           // if (!result.IsValid)
           // {
               // throw new ValidationException(result.Errors);
            //}
        //}
    }
}
