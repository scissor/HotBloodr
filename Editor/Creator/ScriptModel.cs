using System.Collections.Generic;
using UnityEngine;

namespace HotBloodr.Editor
{
    [CreateAssetMenu(menuName = "HotBloodr/Wizard/Script", fileName = "ScriptModel")]
    public class ScriptModel : ScriptableObject
    {
        public GameObject GameObject;
        public string NameSpace;
        public string ClassName;
        public Dictionary<GameObject, string> Members = new Dictionary<GameObject, string>();
    }
}