using System.CodeDom;

namespace ECAIService.Proxy;

public record class ShortCircuitableSample(int Value)
{
    public static bool operator true(ShortCircuitableSample obj)
    {
        return obj.Value != 0;
    }

    public static bool operator false(ShortCircuitableSample obj)
    {
        return obj.Value == 0;
    }

    public static ShortCircuitableSample operator &(ShortCircuitableSample left, ShortCircuitableSample right)
    {
        if (left.Value == 0) return left;
        return right;
    }

    public ShortCircuitableSample Print()
    {
        Console.WriteLine(Value);
        return this;
    }

    public static ShortCircuitableSample Test()
    {
        return (new ShortCircuitableSample(0).Print().Out(out var v01) 
            && v01.Print().Out(out v01)!).Be(v01)!;
    }
}
