using UnityEditor;
using UnityEngine;

namespace TestNovel.Scripts.ConfigurationScripts.CustomConfigurationEditors
{
    [CustomEditor(typeof(Character))]
    public class CharacterEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();
            
            if (GUILayout.Button("Reset emotions configuration"))
            {
                var a = Character.GetEmotionsToView();
                var views = serializedObject.FindProperty("CharacterViews");
                views.ClearArray();
                views.arraySize = a.Count;
                for (var i = 0; i < a.Count; i++)
                {
                    var element = views.GetArrayElementAtIndex(i);
                    var b = a[i];
                    element.FindPropertyRelative("Emotion").enumValueIndex = (int)b.Emotion;
                }
            }
            
            if (GUI.changed)
            {
                serializedObject.ApplyModifiedProperties();
            }
        }
    }
}