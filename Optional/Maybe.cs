using System;

namespace Optional
{
    public abstract class Maybe<T> : IOptional<T>
    {
        private readonly T _value;

        public bool IsNone => this is Nothing;
        public bool IsSome => this is Just;

        public T GetWithDefault(T fallback) => IsSome ? _value : fallback;

        public IOptional<U> Map<U>(Func<T, IOptional<U>> f) => IsSome ? f(_value) : Maybe<U>.Nothing_();

        private Maybe() { }

        private Maybe( T value) => _value = value;

        public sealed class Nothing : Maybe<T>
        {
            private Nothing() { }
            public static Maybe<T> Make() => new Nothing();

        }

        public sealed class Just : Maybe<T>
        {
            public T Value => _value;
            private Just(T value) : base(value){}
            public static Maybe<T> Make(T value) => value != null ?  new Just(value) : Nothing.Make();
        }

        public static Maybe<T> Just_(T value) => Just.Make(value);
        public static Maybe<T> Nothing_() => Nothing.Make();
    }
}
