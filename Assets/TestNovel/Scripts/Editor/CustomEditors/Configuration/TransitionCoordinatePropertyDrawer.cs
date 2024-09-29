using UnityEditor;
using UnityEngine;

namespace TestNovel.Scripts.ConfigurationScripts.CustomConfigurationEditors
{
    [CustomPropertyDrawer(typeof(TransitionCoordinate))]
    public class TransitionCoordinatePropertyDrawer : PropertyDrawer
    {
        private SerializedProperty _presetPositionProperty;
        private SerializedProperty _positionProperty;

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            _presetPositionProperty ??= property.FindPropertyRelative("presetPosition");
            
            var linesToDraw = (IsCustomScreenPosition() ? 3 : 2);
            return EditorGUIUtility.singleLineHeight * linesToDraw + 5; 
        }

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            const int horizontalShiftToOptionalParameter = 30;
            EditorGUI.BeginProperty(position, label, property);

            Rect positionLocal = position;
            positionLocal.height = EditorGUIUtility.singleLineHeight;
            
            _presetPositionProperty ??= property.FindPropertyRelative("presetPosition");
            _positionProperty ??= property.FindPropertyRelative("xCoordinate");

            EditorGUI.LabelField(positionLocal, property.name);
            positionLocal.x += horizontalShiftToOptionalParameter;
            positionLocal.width -= horizontalShiftToOptionalParameter;
            AddOffset();
            
            EditorGUI.PropertyField(positionLocal, _presetPositionProperty, new GUIContent(_presetPositionProperty.name));

            if (IsCustomScreenPosition())
            {
                AddOffset();
                EditorGUI.PropertyField(positionLocal, _positionProperty, new GUIContent(_positionProperty.name));
            }
            else
            {
                _positionProperty.floatValue = TransitionCoordinate.CoordinateMapping(
                    (EScreenPosition)_presetPositionProperty.enumValueIndex, _positionProperty.floatValue);
            }
            
            EditorGUI.EndProperty();

            void AddOffset() => positionLocal.y += EditorGUIUtility.singleLineHeight;
        }

        private bool IsCustomScreenPosition()
        {
            EScreenPosition value = (EScreenPosition)_presetPositionProperty.enumValueIndex;
            return value == EScreenPosition.Custom;
        }
    }
}