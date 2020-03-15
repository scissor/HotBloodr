using System.IO;
using UnityEditor;
using UnityEngine;

namespace HotBloodr
{
    public static class ScriptableObjectUtility
    {
        public static T CreateAsset<T>() where T : ScriptableObject
        {
            return CreateAsset<T>(Selection.activeObject);
        }

        public static T CreateAsset<T>(Object target) where T : ScriptableObject
        {
            var asset = ScriptableObject.CreateInstance<T>();

            var path = AssetDatabase.GetAssetPath(target);
            if (path == "")
            {
                path = "Assets";
            }
            else if (Path.GetExtension(path) != "")
            {
                path = path.Replace(Path.GetFileName(AssetDatabase.GetAssetPath(Selection.activeObject)), "");
            }

            var assetPathAndName = AssetDatabase.GenerateUniqueAssetPath($"{path}/New {typeof(T)}.asset");

            AssetDatabase.CreateAsset(asset, assetPathAndName);
            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();
            EditorUtility.FocusProjectWindow();
            Selection.activeObject = asset;

            return asset;
        }
    }
}