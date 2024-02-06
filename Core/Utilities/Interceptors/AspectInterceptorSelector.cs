using Castle.DynamicProxy;
using System.Reflection;

namespace Core.Utilities.Interceptors
{
    //git 
    public class AspectInterceptorSelector : IInterceptorSelector
    {
        public IInterceptor[] SelectInterceptors(Type type, MethodInfo method, IInterceptor[] interceptors)
        {
            var classAttributes = type.GetCustomAttributes<MethodInterceptionBaseAttribute>
                (true).ToList();//git clasın attiributlerini oku 
            var methodAttributes = type.GetMethod(method.Name)
                .GetCustomAttributes<MethodInterceptionBaseAttribute>(true);
            classAttributes.AddRange(methodAttributes);//bit methodun attirbutlarını oku 
            //ve onları bir listeye koy IInterceptor[] 

           // classAttributes.Add(new ExceptionLogAspect(typeof(FileLogger))); tüm heryere loglama yapar

            return classAttributes.OrderBy(x => x.Priority).ToArray();
        }
    }
}
