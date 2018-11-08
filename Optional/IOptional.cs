using System;

namespace Optional
{
    public interface IOptional<T>
    {
        bool IsNone { get; }
        bool IsSome { get; }

        T GetWithDefault(T fallback);

        IOptional<U> Map<U>(Func<T, IOptional<U>> f);
    }
}
