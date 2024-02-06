using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Interceptors;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Aspects.Autofac.Validation
{
    public class ValidationAspect : MethodInterception //aspectdir aspect demeke methodun sonunda başında çalışması gerekn yapı 
    {//sen bir methodinterceptionsun 
        //validaton aspect sen bir attiributsun çünkü methotintercaptor  methotintercaptorbase in kuralarını miras alır oda attiributur bu yüzden validator aspecte attiributur 
        private Type _validatorType;
        public ValidationAspect(Type validatorType)
        {//abstaracvalidator bir ı validatordur 
            if (!typeof(IValidator).IsAssignableFrom(validatorType))//burada ı validator olması sayesinde car validator mu eğer değilse expection at eğer car validator ise _validatortype eşitle 
            {
                throw new System.Exception("Bu bir doğrulama sınıfı değil");
            }

            _validatorType = validatorType;
        }
        //methotinterceptiondaki virtul olan on beforu burada eziyoruz 
        protected override void OnBefore(IInvocation invocation)
        {//çalışma anında instance oluşturduk reflaction 
            //car mangerde yazdığımız validate instance yok bunu çalışma anında activator createinstence yapıyor bizim yerimize 
            var validator = (IValidator)Activator.CreateInstance(_validatorType);//car validatoru newledi bizim için instance üretir (car  add type of productdur )
            var entityType = _validatorType.BaseType.GetGenericArguments()[0];//buradada validator type ==carvalidator onun gereic yapan argumanına yani car ı yakala 
            var entities = invocation.Arguments.Where(t => t.GetType() == entityType);//invocation carmangerdaki 
            //methodlarımı gez eğer oradki eğer ordaki tip benim entitiyeype car tipinde  ise onu validate et 
            foreach (var entity in entities)
            {
                ValidationTool.Validate(validator, entity);
            }
        }
    }
}
