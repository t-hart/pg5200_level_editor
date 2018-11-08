using System;
using JetBrains.Annotations;

namespace Optional
{
    public abstract class Maybe<T> : IOptional<T>
    {
        private readonly T _value;

        public bool IsNone { get; }
        public bool IsSome => !IsNone;

        public T GetWithDefault(T fallback) => IsSome ? _value : fallback;

        public IOptional<U> Map<U>(Func<T, IOptional<U>> f) => IsSome ? f(_value) : new  Maybe<U>.Nothing();

        private Maybe()
        {
            IsNone = true;
        }

        private Maybe([NotNull] T value)
        {
            _value = value;
            IsNone = false;
        }

        public sealed class Nothing : Maybe<T> { }

        public sealed class Just : Maybe<T>
        {
            public Just([NotNull] T value) : base(value) { }
        }
    }

}
