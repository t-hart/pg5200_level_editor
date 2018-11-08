using System;
using JetBrains.Annotations;

namespace Optional
{
    public sealed class Option<T> : IOptional<T>
    {
        private readonly T _value;

        public bool IsNone { get; }
        public bool IsSome => !IsNone;

        public T GetWithDefault(T fallback) => IsSome ? _value : fallback;

        public IOptional<U> Map<U>(Func<T, IOptional<U>> f) => IsSome ? f(_value) : Option<U>.None();


        private Option()
        {
            IsNone = true;
        }

        private Option([NotNull] T val)
        {
            _value = val;
            IsNone = false;
        }

        public static Option<T> Some([NotNull] T value) => new Option<T>(value);

        public static Option<T> None() => new Option<T>();
    }
}
