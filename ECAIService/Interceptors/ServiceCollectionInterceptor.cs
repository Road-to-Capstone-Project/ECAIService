using System.Reflection;

using Castle.DynamicProxy;

namespace ECAIService.Interceptors;

public class ServiceCollectionInterceptor : IInterceptor
{
    private readonly MethodInfo addMethodInfo = typeof(IList<ServiceDescriptor>)
        .GetMethod(nameof(IList<ServiceDescriptor>.Add))!;

    public void Intercept(IInvocation invocation)
    {
        if (invocation.MethodInvocationTarget == addMethodInfo)
        {
            var serviceDescriptor = (ServiceDescriptor)invocation.Arguments[0];

            if (serviceDescriptor.ImplementationInstance is not null)
            {

            }

            invocation.Proceed();
        }
    }
}
