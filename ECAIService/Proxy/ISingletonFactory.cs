namespace ECAIService.Proxy;

public interface ISingletonFactory<T>
{
    ISingleton<T> FromValue(T value);

    ISingleton<T> FromDelegates(Func<T> getter, Action<T> setter);
}

public class SingletonFactory<T> : ISingletonFactory<T>
{
    public SingletonFactory(ISingletonFactory<T> proxy)
    {
        Proxy = proxy ?? this;
    }

    public SingletonFactory(Func<ISingletonFactory<T>, ISingletonFactory<T>> proxyFactory, out ISingletonFactory<T> proxy)
    {
        Proxy = proxyFactory(this);
        proxy = Proxy;
    }

    public ISingletonFactory<T> FromProxy(Func<ISingletonFactory<T>, ISingletonFactory<T>> proxyFactory)
    {
        return new SingletonFactory<T>(proxyFactory, out var result).Be(result);
    }

    protected ISingletonFactory<T> Proxy { get; }

    public ISingleton<T> FromDelegates(Func<T> getter, Action<T> setter)
    {
        return new SingletonImpl<T>(getter, setter);
    }

    public ISingleton<T> FromValue(T value)
    {
        return Proxy.FromDelegates(() => value, i => value = i);
    }
}
