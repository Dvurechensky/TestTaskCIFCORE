﻿/*
 * Author: Nikolay Dvurechensky
 * Site: https://www.dvurechensky.pro/
 * Gmail: dvurechenskysoft@gmail.com
 * Last Updated: 12 мая 2025 08:07:05
 * Version: 1.0.1
 */

// for uGUI(from 4.6)
#if !(UNITY_4_0 || UNITY_4_1 || UNITY_4_2 || UNITY_4_3 || UNITY_4_4 || UNITY_4_5)

using System; // require keep for Windows Universal App
using UnityEngine;
using UnityEngine.EventSystems;

namespace UniRx.Triggers
{
    [DisallowMultipleComponent]
    public class ObservableEndDragTrigger : ObservableTriggerBase, IEventSystemHandler, IEndDragHandler
    {
        Subject<PointerEventData> onEndDrag;

        void IEndDragHandler.OnEndDrag(PointerEventData eventData)
        {
            if (onEndDrag != null) onEndDrag.OnNext(eventData);
        }

        public IObservable<PointerEventData> OnEndDragAsObservable()
        {
            return onEndDrag ?? (onEndDrag = new Subject<PointerEventData>());
        }

        protected override void RaiseOnCompletedOnDestroy()
        {
            if (onEndDrag != null)
            {
                onEndDrag.OnCompleted();
            }
        }
    }
}


#endif