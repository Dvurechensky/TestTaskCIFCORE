﻿/*
 * Author: Nikolay Dvurechensky
 * Site: https://www.dvurechensky.pro/
 * Gmail: dvurechenskysoft@gmail.com
 * Last Updated: 12 мая 2025 08:07:05
 * Version: 1.0.1
 */

#if CSHARP_7_OR_LATER || (UNITY_2018_3_OR_NEWER && (NET_STANDARD_2_0 || NET_4_6))
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UniRx.InternalUtil
{
    internal static class PromiseHelper
    {
        internal static void TrySetResultAll<T>(IEnumerable<TaskCompletionSource<T>> source, T value)
        {
            var rentArray = source.ToArray(); // better to use Arraypool.
            var array = rentArray;
            var len = rentArray.Length;
            for (int i = 0; i < len; i++)
            {
                array[i].TrySetResult(value);
                array[i] = null;
            }
        }
    }
}

#endif