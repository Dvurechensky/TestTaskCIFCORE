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
    internal class AsUnitObservableObservable<T> : OperatorObservableBase<Unit>
    {
        readonly IObservable<T> source;

        public AsUnitObservableObservable(IObservable<T> source)
            : base(source.IsRequiredSubscribeOnCurrentThread())
        {
            this.source = source;
        }

        protected override IDisposable SubscribeCore(IObserver<Unit> observer, IDisposable cancel)
        {
            return source.Subscribe(new AsUnitObservable(observer, cancel));
        }

        class AsUnitObservable : OperatorObserverBase<T, Unit>
        {
            public AsUnitObservable(IObserver<Unit> observer, IDisposable cancel)
                : base(observer, cancel)
            {
            }

            public override void OnNext(T value)
            {
                base.observer.OnNext(Unit.Default);
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