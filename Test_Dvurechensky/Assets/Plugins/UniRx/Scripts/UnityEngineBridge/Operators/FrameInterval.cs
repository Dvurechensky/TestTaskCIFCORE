﻿/*
 * Author: Nikolay Dvurechensky
 * Site: https://www.dvurechensky.pro/
 * Gmail: dvurechenskysoft@gmail.com
 * Last Updated: 12 мая 2025 08:07:05
 * Version: 1.0.1
 */

using System;

namespace UniRx.Operators
{
    internal class FrameIntervalObservable<T> : OperatorObservableBase<UniRx.FrameInterval<T>>
    {
        readonly IObservable<T> source;

        public FrameIntervalObservable(IObservable<T> source)
            : base(source.IsRequiredSubscribeOnCurrentThread())
        {
            this.source = source;
        }

        protected override IDisposable SubscribeCore(IObserver<UniRx.FrameInterval<T>> observer, IDisposable cancel)
        {
            return source.Subscribe(new FrameInterval(observer, cancel));
        }

        class FrameInterval : OperatorObserverBase<T, UniRx.FrameInterval<T>>
        {
            int lastFrame;

            public FrameInterval(IObserver<UniRx.FrameInterval<T>> observer, IDisposable cancel)
                : base(observer, cancel)
            {
                this.lastFrame = UnityEngine.Time.frameCount;
            }

            public override void OnNext(T value)
            {
                var now = UnityEngine.Time.frameCount;
                var span = now - lastFrame;
                lastFrame = now;

                base.observer.OnNext(new UniRx.FrameInterval<T>(value, span));
            }

            public override void OnError(Exception error)
            {
                try { observer.OnError(error); }
                finally { Dispose(); }
            }

            public override void OnCompleted()
            {
                try { observer.OnCompleted(); }
                finally { Dispose(); }
            }
        }
    }
}