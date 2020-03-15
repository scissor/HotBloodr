using UnityEditor;
using UnityEngine;

namespace HotBloodr.Editor
{
    public abstract class TransformResetter : DecoratorEditor
    {
        private const string RESET_POSITION = "RESET_POSITION";
        private const string RESET_ROTATION = "RESET_ROTATION";
        private const string RESET_SCALE = "RESET_SCALE";

        protected bool m_unFold = false;

        protected static Vector3 m_resetPosition = Vector3.zero;
        protected static Vector3 m_resetRotation = Vector3.zero;
        protected static Vector3 m_resetScale = Vector3.one;

        public TransformResetter(string name) : base(name)
        {
        }

        protected void LoadCustomValues()
        {
            if (EditorPrefs.HasKey(RESET_POSITION))
            {
                m_resetPosition = JsonUtility.FromJson<Vector3>(EditorPrefs.GetString(RESET_POSITION));
            }

            if (EditorPrefs.HasKey(RESET_ROTATION))
            {
                m_resetRotation = JsonUtility.FromJson<Vector3>(EditorPrefs.GetString(RESET_ROTATION));
            }

            if (EditorPrefs.HasKey(RESET_SCALE))
            {
                m_resetScale = JsonUtility.FromJson<Vector3>(EditorPrefs.GetString(RESET_SCALE));
            }
        }

        protected void DrawCustomValues()
        {
            string originLabel;
            if (m_resetPosition != Vector3.zero || m_resetRotation != Vector3.zero || m_resetScale != Vector3.one)
            {
                originLabel = "Set Origin [Custom]";
            }
            else
            {
                originLabel = "Set Origin [Default]";
            }

            m_unFold = EditorGUILayout.Foldout(m_unFold, originLabel);
            if (m_unFold)
            {
                EditorGUI.BeginChangeCheck();
                if (GUILayout.Button("Clear Custom Origin", EditorStyles.miniButton))
                {
                    m_resetPosition = Vector3.zero;
                    m_resetRotation = Vector3.zero;
                    m_resetScale = Vector3.one;
                    GUI.FocusControl(null);
                }

                GUI.backgroundColor = Color.white;

                m_resetPosition = EditorGUILayout.Vector3Field("Position", m_resetPosition);
                m_resetRotation = EditorGUILayout.Vector3Field("Rotation", m_resetRotation);
                m_resetScale = EditorGUILayout.Vector3Field("Scale", m_resetScale);

                if (EditorGUI.EndChangeCheck())
                {
                    EditorPrefs.SetString(RESET_POSITION, EditorJsonUtility.ToJson(m_resetPosition));
                    EditorPrefs.SetString(RESET_ROTATION, EditorJsonUtility.ToJson(m_resetRotation));
                    EditorPrefs.SetString(RESET_SCALE, EditorJsonUtility.ToJson(m_resetScale));
                }
            }
        }
    }
}