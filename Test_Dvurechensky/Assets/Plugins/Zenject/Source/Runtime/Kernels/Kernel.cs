﻿/*
 * Author: Nikolay Dvurechensky
 * Site: https://www.dvurechensky.pro/
 * Gmail: dvurechenskysoft@gmail.com
 * Last Updated: 12 мая 2025 08:07:05
 * Version: 1.0.1
 */

using System;
using System.Diagnostics;

namespace Zenject
{
    [DebuggerStepThrough]
    public class Kernel : IInitializable, IDisposable, ITickable, ILateTickable, IFixedTickable, ILateDisposable
    {
        [InjectLocal]
        TickableManager _tickableManager = null;

        [InjectLocal]
        InitializableManager _initializableManager = null;

        [InjectLocal]
        DisposableManager _disposablesManager = null;

        public virtual void Initialize()
        {
            _initializableManager.Initialize();
        }

        public virtual void Dispose()
        {
            _disposablesManager.Dispose();
        }

        public virtual void LateDispose()
        {
            _disposablesManager.LateDispose();
        }

        public virtual void Tick()
        {
            _tickableManager.Update();
        }

        public virtual void LateTick()
        {
            _tickableManager.LateUpdate();
        }

        public virtual void FixedTick()
        {
            _tickableManager.FixedUpdate();
        }
    }
}
