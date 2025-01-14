using Castle.DynamicProxy;

namespace ECAIService.Interceptors;

public class WithCallbackInterceptor : IInterceptor
{
    private readonly Action<IInvocation> callback;

    public WithCallbackInterceptor(Action<IInvocation> interceptorCallback = null!)
    {
        callback = interceptorCallback ?? (_ => { });
    }

    public void Intercept(IInvocation invocation)
    {
        callback(invocation);
    }
}