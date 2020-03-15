using System;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

namespace HotBloodr
{
    public static class EditorGUIHelper
    {
        public static int TitleIntField(string title, int number, bool isHorizontal = false, params GUILayoutOption[] options)
        {
            var returnValue = 0;
            TitleField(title, isHorizontal, () => { returnValue = EditorGUILayout.IntField(number, options); });
            return returnValue;
        }

        public static int TitleIntField(string title, int fontSize, Color color, int number, bool isHorizontal = false,
            params GUILayoutOption[] options)
        {
            var returnValue = 0;
            TitleField(title, fontSize, color, isHorizontal, () => { returnValue = EditorGUILayout.IntField(number, options); });
            return returnValue;
        }

        public static float TitleFloatField(string title, int fontSize, Color color, float number, bool isHorizontal = false,
            params GUILayoutOption[] options)
        {
            var returnValue = 0f;
            TitleField(title, fontSize, color, isHorizontal, () => { returnValue = EditorGUILayout.FloatField(number, options); });
            return returnValue;
        }

        public static float TitleFloatField(string title, float number, bool isHorizontal = false, params GUILayoutOption[] options)
        {
            var returnValue = 0f;
            TitleField(title, isHorizontal, () => { returnValue = EditorGUILayout.FloatField(number, options); });
            return returnValue;
        }

        public static string TitleTextField(string title, int fontSize, Color color, string text, bool isHorizontal = false,
            params GUILayoutOption[] options)
        {
            var returnValue = string.Empty;
            TitleField(title, fontSize, color, isHorizontal, () => { returnValue = EditorGUILayout.TextField(text, options); });
            return returnValue;
        }

        public static string TitleTextField(string title, string text, bool isHorizontal = false, params GUILayoutOption[] options)
        {
            var returnValue = string.Empty;
            TitleField(title, isHorizontal, () => { returnValue = EditorGUILayout.TextField(text, options); });
            return returnValue;
        }

        public static bool TitleToggle(string title, int fontSize, Color color, bool flag, bool isHorizontal = false,
            params GUILayoutOption[] options)
        {
            var returnValue = false;
            TitleField(title, fontSize, color, isHorizontal, () => { returnValue = EditorGUILayout.Toggle(flag, options); });
            return returnValue;
        }

        public static bool TitleToggle(string title, bool flag, bool isHorizontal = false, params GUILayoutOption[] options)
        {
            var returnValue = false;
            TitleField(title, isHorizontal, () => { returnValue = EditorGUILayout.Toggle(flag, options); });
            return returnValue;
        }

        private static void TitleField(string title, bool isHorizontal, Action callback)
        {
            if (isHorizontal)
            {
                GUILayout.BeginHorizontal();
            }

            GUIHelper.FixedLabel(title);
            callback();

            if (isHorizontal)
            {
                GUILayout.EndHorizontal();
            }
        }

        private static void TitleField(string title, int fontSize, Color color, bool isHorizontal, Action callback)
        {
            if (isHorizontal)
            {
                GUILayout.BeginHorizontal();
            }

            GUIHelper.FixedLabel(title, fontSize, color);
            callback();

            if (isHorizontal)
            {
                GUILayout.EndHorizontal();
            }
        }

        public static Enum EnumPopup(Enum type, int width, int height, int fontSize = 10)
        {
            var originFontSize = EditorStyles.popup.fontSize;
            var originHeight = EditorStyles.popup.fixedHeight;
            EditorStyles.popup.fontSize = fontSize;
            EditorStyles.popup.fixedHeight = height;

            var returnType = EditorGUILayout.EnumPopup(type, GUILayout.Width(width), GUILayout.Height(height));
            EditorStyles.popup.fontSize = originFontSize;
            EditorStyles.popup.fixedHeight = originHeight;

            return returnType;
        }

        public static bool DrawListWithAddRemoveButtons<T>(List<T> list, T item, Color color, Action<int> callback)
        {
            if (!list.Any())
            {
                GUIHelper.DrawAddRemoveButtons(list, item, -1, color);
            }

            for (int i = 0; i < list.Count; i++)
            {
                GUILayout.BeginHorizontal();
                {
                    if (GUIHelper.DrawAddRemoveButtons(list, item, i, color))
                    {
                        return true;
                    }

                    callback(i);
                }
                GUILayout.EndHorizontal();
            }

            return false;
        }
    }
}