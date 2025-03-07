using System.Diagnostics.CodeAnalysis;

namespace ECAIService.Proxy;

public readonly record struct ShortCircuitableExpression<T>(T Value, Predicate<T>? ShortCircuitPredicate)
{
    public static bool operator true(ShortCircuitableExpression<T> obj)
    {
        return obj.ShortCircuitPredicate is null || !obj.ShortCircuitPredicate(obj.Value);
    }

    public static bool operator false(ShortCircuitableExpression<T> obj)
    {
        return obj.ShortCircuitPredicate is not null && obj.ShortCircuitPredicate(obj.Value);
    }

    public static implicit operator ShortCircuitableExpression<T>(T value)
    {
        return new(value, null);
    }

    public static ShortCircuitableExpression<T> operator &(ShortCircuitableExpression<T> left, ShortCircuitableExpression<T> right)
    {
        if (left.ShortCircuitPredicate is not null && left.ShortCircuitPredicate(left.Value)) return left;
        return new (right.Value, right.ShortCircuitPredicate ?? left.ShortCircuitPredicate);
    }

    private static void Print(int[] array)
    {
        Console.WriteLine(string.Join(", ", array));
    }

    public ShortCircuitableExpression<T> MapValue(Func<T, T> selector)
    {
        return this with { Value = selector(Value) };
    }

    public static void Test()
    {
        var expression =
            new ShortCircuitableExpression<IEnumerable<int>>(Enumerable.Range(0, 10).ToArray(), i => 
            i.Count() < 5);



        var str = (expression
            .Out(out var it)
            .Out(out var it2)
            .Out(out var it3)
            && it.MapValue(i => i.Where(i => i >= 2).ToArray().Apply(Print))
            .RefOut(ref it, out it2)
            && (it with { Value = it.Value.Where(i => i > 4).ToArray().Apply(Print) })
            .RefOut(ref it, out it2)
            && (it with { Value = it.Value.Where(i => i > 5).ToArray().Apply(Print) })
            .RefOut(ref it, out it2)
            && (it with { Value = it.Value.Where(i => i > 8).ToArray().Apply(Print) })
            .RefOut(ref it, out it2)
            )
            .Be(it2)
            .Let(it => string.Join(", ", it.Value));

        Console.WriteLine(
            str
            );
    }
}
