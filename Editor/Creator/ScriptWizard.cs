using System.Collections.Generic;
using System.IO;

namespace HotBloodr.Editor
{
    public class ScriptWizard
    {
        public static string Create(string name, Dictionary<string, string> replacements)
        {
            var path = HotBloodrSettings.I.ScriptTemplatePath + name;
            var script = File.ReadAllText(path);
            foreach (var pair in replacements)
            {
                script = script.Replace(pair.Key, pair.Value);
            }

            return script;
        }
    }
}