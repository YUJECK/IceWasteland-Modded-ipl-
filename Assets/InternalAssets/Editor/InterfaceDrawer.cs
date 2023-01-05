using UnityEditor;
using UnityEngine;

namespace AutumnForest.Editor
{
    [CustomPropertyDrawer(typeof(InterfaceAttribute))]
    public class InterfaceDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            InterfaceAttribute interfaceAttribute = attribute as InterfaceAttribute;
            property.objectReferenceValue = EditorGUI.ObjectField(position, label, property.objectReferenceValue, interfaceAttribute.requiredType, true);
        }
    }
}