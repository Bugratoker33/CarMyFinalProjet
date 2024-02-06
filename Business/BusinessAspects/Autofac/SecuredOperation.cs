using Business.Constants;
using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
using Core.Utilities.IoC;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Extensions;

namespace Business.BusinessAspects.Autofac
{
    /// JWT İÇİN ASPECT ÇÜNKÜ İLERİDE YETKİLENDİRME SERVİCEMİZ DEĞİŞEBİLİR 
    public class SecuredOperation : MethodInterception
    {
        private string[] _roles;
        private IHttpContextAccessor _httpContextAccessor;//JWT DÖNDEREK İSTEK YAPIYORUZ YA HER BİR İSTEK İÇİN BİR HTTPCONTEXT OLUŞTURUR 

        public SecuredOperation(string roles)
        {
            _roles = roles.Split(',');
            _httpContextAccessor = ServiceTool.ServiceProvider.GetService<IHttpContextAccessor>();
            /// DPENDENC YAKALAYABİLMEK İÇİN BİR ADET --SERVİCETOOL YAZALIM --
            /// SERVİCETOOL BİZİM İNJECTİON ALT YAPIMIZI AYNEN OKUYABİLMEMİZİ YARIYAN ARAÇ OLACAK 
            /// /// aspect olduğu için yapamıyoruz o zaman service tool ile biz kendimiz yazdık 
        }

        protected override void OnBefore(IInvocation invocation)
        {
            var roleClaims = _httpContextAccessor.HttpContext.User.ClaimRoles();//o naki kulanıcın clam rolerini bul claimsprincipal 
            foreach (var role in _roles)
            {
                if (roleClaims.Contains(role))//eğer claimlerinin içinde ilgili rol varse metodu çalıştır 
                {
                    return;
                }
            }
            throw new Exception(Messages.AuthorizationDenied);
        }
    }
}
