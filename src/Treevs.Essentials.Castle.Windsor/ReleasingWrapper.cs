﻿namespace Treevs.Essentials.Castle.Windsor
{
    using System;

    public interface IReleaser<T>
    {
        void Release(T obj);
    }

    public static class ReleasingWrapper
    {
        public static WrappingObject<TSubject> CreateReleasable<TSubject, TFactory>(
            this TFactory releaser,
            Func<TFactory, TSubject> createFunc) where TFactory : IReleaser<TSubject>
        {
            return new WrappingObject<TSubject>(createFunc(releaser), releaser.Release);
        }
    }

    public class WrappingObject<T> : IDisposable
    {
        private readonly Action<T> _releaseFunc;

        public WrappingObject(T obj, Action<T> releaseFunc)
        {
            this.Object = obj;
            this._releaseFunc = releaseFunc;
        }

        public static implicit operator T(WrappingObject<T> o)
        {
            return o.Object;
        }

        public T Object { get; private set; }

        public void Dispose()
        {
            this._releaseFunc(this.Object);
        }
    }
}
