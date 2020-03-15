using UnityEngine;

namespace HotBloodr
{
    public class HotBloodrSettings : ResourcesScriptableSingleton<HotBloodrSettings>
    {
        [SerializeField]
        private string m_rootPath;

        [SerializeField]
        private string m_scriptTemplatePath;

        public string RootPath => m_rootPath;

        public string ScriptTemplatePath => $"{m_rootPath}{m_scriptTemplatePath}";
    }
}