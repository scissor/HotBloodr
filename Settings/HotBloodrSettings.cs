using UnityEngine;

namespace HotBloodr
{
    public class HotBloodrSettings : ResourcesScriptableSingleton<HotBloodrSettings>
    {
        [SerializeField]
        private string m_rootPath;

        [SerializeField]
        private string m_scriptTemplatePath;

        [SerializeField]
        private string m_iconPath;

        public string RootPath => m_rootPath;

        public string ScriptTemplatePath => $"{m_rootPath}{m_scriptTemplatePath}";

        public string IconPath => $"{m_rootPath}{m_iconPath}";
    }
}