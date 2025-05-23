﻿/*
 * Author: Nikolay Dvurechensky
 * Site: https://www.dvurechensky.pro/
 * Gmail: dvurechenskysoft@gmail.com
 * Last Updated: 12 мая 2025 08:07:05
 * Version: 1.0.1
 */

// after uGUI(from 4.6)
#if !(UNITY_4_0 || UNITY_4_1 || UNITY_4_2 || UNITY_4_3 || UNITY_4_4 || UNITY_4_5)

using System;
using UnityEngine;

namespace UniRx.Triggers
{
    [DisallowMultipleComponent]
    public class ObservableCanvasGroupChangedTrigger : ObservableTriggerBase
    {
        Subject<Unit> onCanvasGroupChanged;

        // Callback that is sent if the canvas group is changed
        void OnCanvasGroupChanged()
        {
            if (onCanvasGroupChanged != null) onCanvasGroupChanged.OnNext(Unit.Default);
        }

        /// <summary>Callback that is sent if the canvas group is changed.</summary>
        public IObservable<Unit> OnCanvasGroupChangedAsObservable()
        {
            return onCanvasGroupChanged ?? (onCanvasGroupChanged = new Subject<Unit>());
        }

        protected override void RaiseOnCompletedOnDestroy()
        {
            if (onCanvasGroupChanged != null)
            {
                onCanvasGroupChanged.OnCompleted();
            }
        }
    }
}

#endif