using UnityEditor;
using UnityEngine;

namespace HotBloodr.Editor
{
    [CustomEditor(typeof(RectTransform)), CanEditMultipleObjects]
    public class RectTransformInspector : TransformResetter
    {
        SerializedProperty m_position;
        SerializedProperty m_positionZ;
        SerializedProperty m_rotation;
        SerializedProperty m_scale;

        public RectTransformInspector() : base("RectTransformEditor")
        {
        }

        void OnEnable()
        {
            m_position = serializedObject.FindProperty("m_AnchoredPosition");
            m_positionZ = serializedObject.FindProperty("m_LocalPosition.z");
            m_rotation = serializedObject.FindProperty("m_LocalRotation");
            m_scale = serializedObject.FindProperty("m_LocalScale");

            LoadCustomValues();
        }

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            EditorGUILayout.BeginHorizontal();
            GUI.backgroundColor = new Color(0.75f, 1, 0);

            if (GUILayout.Button("Position", EditorStyles.miniButtonLeft))
            {
                m_position.vector2Value = m_resetPosition;
                m_positionZ.floatValue = m_resetPosition.z;
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