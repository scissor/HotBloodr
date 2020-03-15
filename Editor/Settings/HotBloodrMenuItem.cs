using UnityEditor;
using UnityEngine;

namespace HotBloodr.Editor
{
    public static class HotBloodrMenuItem
    {
        [MenuItem("HotBloodr/Tools/PrefabSearcher")]
        public static void OpenPrefabSearcher()
        {
            var window = EditorWindow.GetWindow(typeof(PrefabSearcher));
            window.titleContent = new GUIContent("Prefab Searcher");
        }

        [MenuItem("HotBloodr/Tools/MaterialPropertyCleaner")]
        private static void OpenMaterialPropertyCleaner()
        {
            var window = EditorWindow.GetWindow(typeof(MaterialPropertyCleaner));
            window.titleContent = new GUIContent("Material Cleaner");
        }
    }
}