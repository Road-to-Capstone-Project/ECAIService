using Castle.DynamicProxy;

namespace ECAIService.Interceptors;

public class DefaultValueInterceptor : IInterceptor
{
    public void Intercept(IInvocation invocation)
    {
        var concreteMethod = invocation.GetConcreteMethod();

        if (invocation.MethodInvocationTarget != null)
        {
            invocation.Proceed();
        }
        else if (invocation.ReturnValue is null && concreteMethod.ReturnType.IsValueType && concreteMethod.ReturnType.Equals(typeof(void)).Not())
        // ensure valid return value
        {
            invocation.ReturnValue = Activator.CreateInstance(concreteMethod.ReturnType);
        }
    }
}
