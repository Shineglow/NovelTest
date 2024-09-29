using UnityEditor;
using UnityEngine;

namespace TestNovel.Scripts.ConfigurationScripts.CustomConfigurationEditors
{
    [CustomEditor(typeof(CharacterEmotionsConfiguration))]
    public class CharacterEmotionsConfigurationEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();
            
            if (GUILayout.Button("Reset emotions configuration"))
            {
                var a = CharacterEmotionsConfiguration.GetEmotionsToView();
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