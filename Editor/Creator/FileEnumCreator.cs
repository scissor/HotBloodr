using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using UnityEditor;
using UnityEngine;

namespace HotBloodr.Editor
{
    public static class FileEnumCreator
    {
        private const string m_templateName = "FileEnum.txt";
        private static readonly string m_root = Application.dataPath + "/Scripts/Enum/";

        public static void OpenWindow()
        {
            string path = EditorUtility.OpenFolderPanel("Load...", "", "");
            if (path.Length != 0)
            {
                CreateEnumFile(path);
            }
        }

        private static List<string> GetFiles(string folder)
        {
            return Directory.GetFiles(folder).Where(f => !f.EndsWith(".meta")).ToList();
        }

        private static void CreateEnumFile(string folder)
        {
            var enumName = folder.Split('/').Last();
            var className = enumName + "Class";

            var enums = string.Empty;
            var files = GetFiles(folder);
            foreach (var file in files)
            {
                var fileName = file.Split('/').Last();
                fileName = fileName.Split('.').First();
                enums += fileName + ",\n\t";
            }

            var replacements = new Dictionary<string, string>()
            {
                {"$EnumName", enumName},
                {"$Enums", enums},
            };
            var fileString = ScriptWizard.Create(m_templateName, replacements);
            if (!Directory.Exists(m_root))
            {
                Directory.CreateDirectory(m_root);
            }

            File.WriteAllText(m_root + "/" + className + ".cs", fileString, Encoding.UTF8);
            AssetDatabase.Refresh();
        }
    }
}