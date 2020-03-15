using System.Collections.Generic;
using UnityEngine;

namespace HotBloodr.Editor
{
    [CreateAssetMenu(menuName = "HotBloodr/Wizard/Project", fileName = "ProjectModel")]
    public class ProjectModel : ScriptableObject
    {
        public List<ScriptModel> Scripts = new List<ScriptModel>();
    }
}