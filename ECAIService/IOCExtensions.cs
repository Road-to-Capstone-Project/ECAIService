using Castle.DynamicProxy;

namespace ECAIService;

public static class IOCExtensions
{
    public static void AddProxiedScoped<TInterface, TImplementation>(this IServiceCollection services)
    where TInterface : class
    where TImplementation : class, TInterface
    {
        services.AddScoped<TImplementation>();
        services.AddScoped(serviceProvider =>
        {
            var proxyGenerator = serviceProvider.GetRequiredService<ProxyGenerator>();
            var actual = serviceProvider.GetRequiredService<TImplementation>();
            var interceptors = serviceProvider.GetServices<IInterceptor>().ToArray();
            return proxyGenerator.CreateInterfaceProxyWithTarget<TInterface>(actual, interceptors);
        });
    }

    public static void AddProxiedSingleton<TInterface, TImplementation>(this IServiceCollection services)
    where TInterface : class
    where TImplementation : class, TInterface
    {
        services.AddSingleton<TImplementation>();
        services.AddSingleton(serviceProvider =>
        {
            var proxyGenerator = serviceProvider.GetRequiredService<ProxyGenerator>();
            var actual = serviceProvider.GetRequiredService<TImplementation>();
            var interceptors = serviceProvider.GetServices<IInterceptor>().ToArray();
            return proxyGenerator.CreateInterfaceProxyWithTarget<TInterface>(actual, interceptors);
        });
    }

    public static void AddProxiedTransient<TInterface, TImplementation>(this IServiceCollection services)
    where TInterface : class
    where TImplementation : class, TInterface
    {
        services.AddTransient<TImplementation>();
        services.AddTransient(serviceProvider =>
        {
            var proxyGenerator = serviceProvider.GetRequiredService<ProxyGenerator>();
            var actual = serviceProvider.GetRequiredService<TImplementation>();
            var interceptors = serviceProvider.GetServices<IInterceptor>().ToArray();
            return proxyGenerator.CreateInterfaceProxyWithTarget<TInterface>(actual, interceptors);
        });
    }
}
