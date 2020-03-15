using UnityEditor;
using UnityEngine;

namespace HotBloodr.Editor
{
    [CustomEditor(typeof(CameraVideoPlayer), true)]
    public class CameraVideoPlayerEditor : UnityEditor.Editor
    {
        private const int BUTTON_WIDTH = 40;

        private CameraVideoPlayer m_player;

        private void OnEnable()
        {
            m_player = target as CameraVideoPlayer;
        }

        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();

            if (m_player == null)
            {
                Debug.Log("Player is null");
                return;
            }

            DrawTime();
            DrawProgressSlider();
            DrawControlButtons();

            Repaint();
        }

        private void DrawTime()
        {
            GUILayout.BeginHorizontal();
            {
                GUIHelper.FontLabel(m_player.NowTime + "/" + m_player.TotalTime, 18, Color.red);
            }
            GUILayout.EndHorizontal();
        }

        private void DrawProgressSlider()
        {
            GUILayout.BeginHorizontal();
            {
                GUILayout.HorizontalSlider(m_player.Progress, 0, 1);
            }
            GUILayout.EndHorizontal();
        }

        private void DrawControlButtons()
        {
            GUI.backgroundColor = Color.red;
            GUILayout.BeginHorizontal();
            {
                var playString = m_player.IsPlaying ? "▌▌" : "▶";
                if (GUIHelper.Button(playString, BUTTON_WIDTH, BUTTON_WIDTH))
                {
                    if (m_player.IsPlaying)
                    {
                        m_player.Pause();
                    }
                    else
                    {
                        m_player.Play();
                    }
                }

                if (GUIHelper.Button("▇", BUTTON_WIDTH, BUTTON_WIDTH))
                {
                    m_player.Stop();
                }
            }
            GUI.backgroundColor = Color.white;
            GUILayout.EndHorizontal();
        }
    }
}