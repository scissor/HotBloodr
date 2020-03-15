using UnityEditor;
using UnityEngine;

namespace HotBloodr.Editor
{
    [CustomEditor(typeof(AnimatorTester)), CanEditMultipleObjects]
    public class AnimatorTesterEditor : UnityEditor.Editor
    {
        private const int BUTTON_WIDTH = 20;
        private const int STATE_FONT_SIZE = 18;

        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();

            DrawStates();

            var tester = target as AnimatorTester;
            var labelStyle = new GUIStyle(GUI.skin.label);
            labelStyle.fontSize = STATE_FONT_SIZE;

            // Next & Previous Button
            GUILayout.BeginHorizontal();
            GUI.backgroundColor = Color.green;
            {
                if (GUILayout.Button("<<"))
                {
                    tester.Previous();
                }

                GUILayout.FlexibleSpace();
                GUILayout.Label(tester.State, labelStyle);
                GUILayout.FlexibleSpace();

                if (GUILayout.Button(">>"))
                {
                    tester.Next();
                }
            }
            GUILayout.EndHorizontal();

            // AutoTest Toggle
            GUI.backgroundColor = Color.white;
            GUIHelper.HorizontalSplitter(1);
            GUILayout.Space(5);
            tester.IsAuto = GUILayout.Toggle(tester.IsAuto, "AutoTest");
            GUILayout.Space(5);

            // Reset Button
            GUI.backgroundColor = Color.yellow;
            {
                if (GUILayout.Button("Reset"))
                {
                    tester.Initialize();
                }
            }
            GUI.backgroundColor = Color.white;
        }

        private void DrawStates()
        {
            var tester = target as AnimatorTester;
            if (tester.States != null)
            {
                foreach (var state in tester.States)
                {
                    GUILayout.BeginHorizontal();
                    {
                        GUILayout.Label(state);
                        GUI.backgroundColor = Color.red;
                        if (GUILayout.Button("▶", GUILayout.Width(BUTTON_WIDTH)))
                        {
                            tester.Play(state);
                        }

                        GUI.backgroundColor = Color.white;
                        GUILayout.EndHorizontal();
                    }
                }

                GUILayout.Space(10);
            }
        }
    }
}