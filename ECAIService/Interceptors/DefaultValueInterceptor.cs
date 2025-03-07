using Castle.DynamicProxy;

namespace ECAIService.Interceptors;

/// <summary>
/// Ensures that the intercepted method returns a default value.
/// </summary>
///
public class DefaultValueInterceptor(bool useParameterlessConstructor) : IInterceptor
{
    public DefaultValueInterceptor() : this(false)
    {
    }

    public void Intercept(IInvocation invocation)
    {
        var concreteMethod = invocation.GetConcreteMethod();

        if (invocation.MethodInvocationTarget != null)
        {
            invocation.Proceed();
        }
        else if (invocation.ReturnValue is null && 
            (
            concreteMethod.ReturnType.IsValueType || 
            useParameterlessConstructor &&
            concreteMethod.ReturnType.GetConstructor(Type.EmptyTypes) != null
            ) && 
            concreteMethod.ReturnType.Equals(typeof(void)).Not())
        // ensure valid return value
        {
            invocation.ReturnValue = Activator.CreateInstance(concreteMethod.ReturnType);
        }
    }
}
