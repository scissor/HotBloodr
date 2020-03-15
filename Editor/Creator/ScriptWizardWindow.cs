using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

namespace HotBloodr.Editor
{
    public class ScriptWizardWindow : HotBloodrWindow
    {
        private ProjectModel m_project;
        private ScriptModel m_script;
        private List<string> m_scriptNames;
        private List<GameObject> m_collapsedObjects = new List<GameObject>();

        private int m_scriptIndex;
        private int m_hierarchy;

        #region HotBloodrWindow

        protected override string Title => "Script Wizard";

        protected override void OnEnable()
        {
            base.OnEnable();
            Reload();
        }

        protected override void OnWindowToolbar()
        {
            GUIHelper.FontLabel("Project: ", 18, Color.green);

            EditorGUI.BeginChangeCheck();

            m_project = EditorGUILayout.ObjectField(m_project, typeof(ProjectModel), true) as ProjectModel;

            if (m_project == null)
            {
                return;
            }

            if (EditorGUI.EndChangeCheck())
            {
                Reload();
            }

            if (GUIHelper.ColorButton("Reload", Color.cyan))
            {
                Reload();
            }

            if (!m_project.Scripts.Any())
            {
                if (GUIHelper.ColorButton("New Script", Color.cyan))
                {
                    var script = ScriptableObjectUtility.CreateAsset<ScriptModel>(m_project);
                    m_project.Scripts.Add(script);
                }

                return;
            }

            GUILayout.Space(10);
            GUI.backgroundColor = Color.yellow;
            {
                m_scriptIndex = EditorGUILayout.Popup(m_scriptIndex, m_scriptNames.ToArray(), GUILayout.Width(200), GUILayout.Height(30));
            }
            GUI.backgroundColor = Color.white;

            if (m_script == m_project.Scripts[m_scriptIndex])
            {
                return;
            }

            ReloadScript();
        }

        protected override void OnWindowGUI()
        {
            if (m_script == null)
            {
                return;
            }

            GUILayout.Space(10);

            using (new EditorGUILayout.HorizontalScope())
            {
                GUIHelper.FixedLabel(" GameObject", 14, Color.green);
                m_script.GameObject =
                    EditorGUILayout.ObjectField(m_script.GameObject, typeof(GameObject), true, GUILayout.Width(200)) as GameObject;
            }

            GUILayout.Space(10);

            m_script.NameSpace = EditorGUIHelper.TitleTextField(" NameSpace", 14, Color.white, m_script.NameSpace, true);
            m_script.ClassName = EditorGUIHelper.TitleTextField(" ClassName", 14, Color.white, m_script.ClassName, true);

            GUIHelper.HorizontalSplitter(1, 10);

            DrawHierarchy();
        }

        #endregion

        private void Reload()
        {
            m_scriptIndex = 0;
            m_scriptNames = m_project.Scripts.Select(s => s.ClassName).ToList();

            if (m_project.Scripts.Count > 0)
            {
                ReloadScript();
            }
        }

        private void ReloadScript()
        {
            m_script = m_project.Scripts[m_scriptIndex];

            if (m_script.GameObject != null)
            {
                foreach (Transform child in m_script.GameObject.transform)
                {
                    m_collapsedObjects.Add(child.gameObject);
                }
            }
        }

        private void DrawHierarchy()
        {
            GUIHelper.FontLabel(" Hierarchy", 18, Color.magenta);
            GUILayout.Space(10);

            m_hierarchy = 0;

            if (m_script.GameObject == null)
            {
                return;
            }

            Traverse(m_script.GameObject);
        }

        private void Traverse(GameObject parent)
        {
            using (new EditorGUILayout.HorizontalScope())
            {
                GUILayout.Space((m_hierarchy + 1) * 20);
                GUIHelper.FontLabel(parent.name, 12, Color.white);
            }

            m_hierarchy++;

            foreach (Transform child in parent.transform)
            {
                Traverse(child.gameObject);
            }

            m_hierarchy--;
        }
    }
}