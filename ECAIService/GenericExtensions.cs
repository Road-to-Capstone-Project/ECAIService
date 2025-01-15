using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ECAIService.PipelineDto;

namespace ECAIService;
public static class GenericExtensions
{
    public static T Apply<T>(this T obj, Action<T> action)
        where T : allows ref struct
    {
        action(obj);
        return obj;
    }

    public static TOut Let<T, TOut>(this T obj, Func<T, TOut> func)
        where T : allows ref struct
        where TOut : allows ref struct
        
    {
        return func(obj);
    }

    public static async Task<T> ApplyAsync<T>(this Task<T> obj, Action<T> action)
    {
        return await obj.ContinueWith(async i => (await i).Apply(action)).Unwrap();
        //return action(await obj);
    }

    public static async Task<TOut> LetAsync<T, TOut>(this Task<T> obj, Func<T, TOut> func)
    {
        return await obj.ContinueWith(async i => (await i).Let(func)).Unwrap();
        //return action(await obj);
    }

    public static TOut Let<T, T0, TOut>(this T obj, Func<T, T0, TOut> func, T0 arg)
        where T : allows ref struct
        where T0 : allows ref struct
        where TOut : allows ref struct
    {
        return func(obj, arg);
    }

    public static TOut Let<T, T0, TOut>(this T obj, Func<T0, T, TOut> func, T0 arg)
        where T : allows ref struct
        where T0 : allows ref struct
        where TOut : allows ref struct
    {
        return func(arg, obj);
    }

    public static IEnumerable<T> SelectMany<T>(this IEnumerable<IEnumerable<T>> source)
    {
        return source.SelectMany(i => i);
    }

    [Obsolete("Do not use in production.")]
    public static TOut Be<T, TOut>(this T _, TOut other)
    {
        return other;
    }

    public static void Fire(this Action action)
    {
        try { action(); }
        catch { }
    }

    public static void Fire(this ReadOnlySpan<Action> actions)
    {
        foreach (var action in actions)
            try { action(); }
            catch { }
    }

    public static T Run<T>(this Func<T> func)
        where T : allows ref struct
    {
        return func();
    }   

    public static bool Not(this bool value)
    {
        return !value;
    }

    public static string JoinToString<T>(this IEnumerable<T> collection, string separator = ",")
    {
        return $"[{string.Join(separator, collection)}]";
    }

    public static IEnumerable<int> GetEnumerator(this Range range)
    {
        return Enumerable.Range(range.Start.Value, range.End.Value - range.Start.Value);
    }

    public static IEnumerable<int> GetEnumerable(this Range range)
    {
        return new RangeEnumerable(range.Start.Value, range.End.Value);
    }

    public static async Task<TResult> Await<TResult>(this Task<Task<TResult>> task)
    {
        return await await task;
    }

    public static object? Null => null;

    public static Task<object?> NullTask { get; } = Task.FromResult<object?>(null);

    public readonly record struct RangeEnumerable(int start, int end) : IEnumerable<int>
    {
        public readonly IEnumerator<int> GetEnumerator()
        {
            for (int i = start; i < end; i++)
            {
                yield return i;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
