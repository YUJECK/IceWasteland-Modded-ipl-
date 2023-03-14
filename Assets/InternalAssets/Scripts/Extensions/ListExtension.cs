using System;
using System.Collections.Generic;
using UnityEngine;

namespace IceWasteland.Extensions
{
    public static class ListExtension
    {
        public static List<T> WriteFromArray<T>(this List<T> list, T[] array)
        {
            if (array == null) throw new NullReferenceException(nameof(array));

            foreach (T item in array)
                list.Add(item);
        
            return list;
        }
    }
}