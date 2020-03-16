using System.Collections.Generic;
using UnityEngine;

namespace HotBloodr.Editor
{
    public class MemberTypeStyleModel
    {
        public MemberType Type;
        public string Postfix;
    }

    public class CodingStyleModel : ScriptableObject
    {
        public string MemberPrefix;
        public List<MemberTypeStyleModel> MemberStyles;
    }
}