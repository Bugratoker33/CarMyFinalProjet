using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.IoC
{
    public static class ServiceTool//ıoc netin verdiği imkanlarla yapıyoruz 
    {
        public static IServiceProvider ServiceProvider { get; private set; }

        public static IServiceCollection Create(IServiceCollection services)//.netin servislerini kulanarak ve onları build et injectionları oluşturur 
        {
            ServiceProvider = services.BuildServiceProvider();
            return services;
        }
    }
}
