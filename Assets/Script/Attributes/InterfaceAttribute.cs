using UnityEngine;
using System;

namespace AutumnForest.Editor
{
    public class InterfaceAttribute : PropertyAttribute
    {
        public Type requiredType { get; private set; }

        public InterfaceAttribute(Type type) => requiredType = type;
    }
}