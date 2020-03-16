using System.Collections.Generic;
using UnityEngine;

namespace HotBloodr.Editor
{
    [CreateAssetMenu(menuName = "HotBloodr/Wizard/Project", fileName = "ProjectModel")]
    public class ProjectModel : ScriptableObject
    {
        public string ProjectName;
        public CodingStyleModel CodingStyle;
        public List<ScriptModel> Scripts = new List<ScriptModel>();
    }
}