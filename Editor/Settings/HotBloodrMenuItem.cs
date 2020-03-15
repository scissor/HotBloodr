using UnityEditor;
using UnityEngine;

namespace HotBloodr.Editor
{
    public static class HotBloodrMenuItem
    {
        #region Create

        [MenuItem("HotBloodr/Create/Singleton Asset", false, 0)]
        private static void OpenSingletonAssetCreator()
        {
            var window = EditorWindow.GetWindow(typeof(SingletonAssetCreator));
            window.titleContent = new GUIContent("Singleton Creator");
        }

        [MenuItem("HotBloodr/Create/File Enum", false, 0)]
        public static void OnClickEnum()
        {
            FileEnumCreator.OpenWindow();
        }

        #endregion

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