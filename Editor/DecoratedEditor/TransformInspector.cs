using UnityEditor;
using UnityEngine;

namespace HotBloodr.Editor
{
    [CustomEditor(typeof(Transform)), CanEditMultipleObjects]
    public class TransformInspector : TransformResetter
    {
        private SerializedProperty m_position;
        private SerializedProperty m_rotation;
        private SerializedProperty m_scale;

        public TransformInspector() : base("TransformInspector")
        {
        }

        void OnEnable()
        {
            m_position = serializedObject.FindProperty("m_LocalPosition");
            m_rotation = serializedObject.FindProperty("m_LocalRotation");
            m_scale = serializedObject.FindProperty("m_LocalScale");

            LoadCustomValues();
        }

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            EditorGUILayout.Space();

            EditorGUILayout.BeginHorizontal();
            GUI.backgroundColor = new Color(0.75f, 1, 0);

            if (GUILayout.Button("Position", EditorStyles.miniButtonLeft))
            {
                m_position.vector3Value = m_resetPosition;
                serializedObject.ApplyModifiedProperties();
                GUI.FocusControl(null);
            }

            if (GUILayout.Button("Rotation", EditorStyles.miniButtonMid))
            {
                m_rotation.quaternionValue = Quaternion.Euler(m_resetRotation);
                serializedObject.ApplyModifiedProperties();
                GUI.FocusControl(null);
            }

            if (GUILayout.Button("Scale", EditorStyles.miniButtonRight))
            {
                m_scale.vector3Value = m_resetScale;
                serializedObject.ApplyModifiedProperties();
                GUI.FocusControl(null);
            }

            EditorGUILayout.EndHorizontal();

            DrawCustomValues();
        }
    }
}