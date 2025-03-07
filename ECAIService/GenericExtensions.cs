using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using ECAIService.PipelineDto;

namespace ECAIService;

[DebuggerStepThrough]
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

    public static (TOut, TOut) Select<T, TOut>(this (T, T) obj, Func<T, TOut> func)
    {
        return (func(obj.Item1), func(obj.Item2));
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

    public static TOut Operate<T, TOut>(this T obj, Func<T, T, TOut> func, T other)
    where T : allows ref struct
    where TOut : allows ref struct
    {
        return func(obj, other);
    }

    public static TOut Let<T, T0, T1, TOut>(this T obj, Func<T, T0, T1, TOut> func, T0 arg, T1 arg1)
    where T : allows ref struct
    where T0 : allows ref struct
    where TOut : allows ref struct
    {
        return func(obj, arg, arg1);
    }

    public static TOut Let<T, T0, T1, TOut>(this T obj, Func<T0, T, T1, TOut> func, T0 arg, T1 arg1)
        where T : allows ref struct
        where T0 : allows ref struct
        where TOut : allows ref struct
    {
        return func(arg, obj, arg1);
    }

    public static TOut Let<T, T0, T1, TOut>(this T obj, Func<T0, T1, T, TOut> func, T0 arg, T1 arg1)
        where T : allows ref struct
        where T0 : allows ref struct
        where TOut : allows ref struct
    {
        return func(arg, arg1, obj);
    }


    public static IEnumerable<T> SelectMany<T>(this IEnumerable<IEnumerable<T>> source)
    {
        return source.SelectMany(i => i);
    }

    //[Obsolete("Do not use in production.")]
    public static TOut Be<T, TOut>(this T _, TOut other)
    {
        return other;
    }

    public static T Out<T>(this T obj, out T state)
    {
        state = obj;
        return obj;
    }

    public static T RefOut<T>(this T obj, ref T state, out T previousState)
    {
        previousState = state;
        state = obj;
        return obj;
    }

    public static T RefRefOut<T>(this T obj, ref T state, ref T previousState, out T previousPreviousState)
    {
        previousPreviousState = previousState;
        previousState = state;
        state = obj;
        return obj;
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

    public static Guid NewGuid(this Random random)
    {
        return GC.AllocateUninitializedArray<byte>(16)
            .Apply(random.NextBytes)
            .Let(it => new Guid(it));
    }

    public static object? Null => null;

    public static ConfiguredTaskAwaitable<object?> NullTask { get; } = Task.FromResult<object?>(null).ConfigureAwait(false);

    public readonly record struct RangeEnumerable(int Start, int End) : IEnumerable<int>
    {
        public readonly IEnumerator<int> GetEnumerator()
        {
            for (int i = Start; i < End; i++)
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
