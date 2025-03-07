namespace ECAIService.Proxy;

public interface ISingleton<T>
{
    T Value { get; set; }
}

public class SingletonImpl<T>(Func<T> getter, Action<T> setter) : ISingleton<T>
{
    public T Value { get => getter(); set => setter(value); }
}