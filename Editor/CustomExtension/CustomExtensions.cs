using UnityEngine;
using UnityEditor;

namespace CustomExtensions 
{
    public class GUIExtension
    {
        private static readonly string bullet = "●";
        private static readonly string diamond = "◆";
        private static readonly string heart = "♥︎";
        private static readonly string triangle = "◀";
        private static readonly string sparkle = "✦";

        private static readonly string star = "★";
        private static readonly string sun = "☀";
        private static readonly string moon = "☽";
        private static readonly string cloud = "☁";
        private static readonly string snow = "❆";

        private static readonly string clover = "✤";
        private static readonly string flower = "✿";
        private static readonly string point = "☚";
        private static readonly string pen = "✎";

        private static readonly string hazard = "☢";
        private static readonly string peace = "✇";
        private static readonly string skull = "☠";
        private static readonly string target = "☉";

        public static Rect CalculateRect(Rect selection, float leftOffset, float rightOffset, float backgroundHeight)
        {
            var position = new Vector2(selection.position.x + leftOffset, selection.position.y);
            var size = new Vector2(selection.size.x + rightOffset - leftOffset, selection.size.y * backgroundHeight);
            return new Rect(position, size);
        }

        public static void DrawLabelStyle(string label, Rect selection, LabelStyle labelStyle)
        {
            var style = new GUIStyle(labelStyle.guiStyle);
            style.alignment = AnchorPosition(labelStyle.anchor);
            Vector2 labelSize = style.CalcSize(new GUIContent(label));
        
            Rect textRect = selection;
            textRect.width += selection.x;
            textRect.x = textRect.width - labelSize.x - 4 + labelStyle.xAdjust;

            EditorGUI.LabelField(textRect, label, style);
        }

        public static void DrawIconStyle(Icon icon, Rect selection, LabelStyle iconStyle)
        {
            var style = new GUIStyle(iconStyle.guiStyle);
            style.alignment = AnchorPosition(iconStyle.anchor);

            Rect iconRect = selection;
            iconRect.x += iconRect.width - 20 + iconStyle.xAdjust;
            iconRect.width = selection.width;

            switch (icon)
            {
                case Icon.None:
                    break;
                case Icon.Bullet:
                    GUI.Label(iconRect, bullet, style);
                    break;
                case Icon.Diamond:
                    GUI.Label(iconRect, diamond, style);
                    break;
                case Icon.Heart:
                    GUI.Label(iconRect, heart, style);
                    break;
                case Icon.Triangle:
                    GUI.Label(iconRect, triangle, style);
                    break;
                case Icon.Sparkle:
                    GUI.Label(iconRect, sparkle, style);
                    break;
                case Icon.Star:
                    GUI.Label(iconRect, star, style);
                    break;
                case Icon.Sun:
                    GUI.Label(iconRect, sun, style);
                    break;
                case Icon.Moon:
                    GUI.Label(iconRect, moon, style);
                    break;
                case Icon.Cloud:
                    GUI.Label(iconRect, cloud, style);
                    break;
                case Icon.Snow:
                    GUI.Label(iconRect, snow, style);
                    break;
                case Icon.Clover:
                    GUI.Label(iconRect, clover, style);
                    break;
                case Icon.Flower:
                    GUI.Label(iconRect, flower, style);
                    break;
                case Icon.Point:
                    GUI.Label(iconRect, point, style);
                    break;
                case Icon.Pen:
                    GUI.Label(iconRect, pen, style);
                    break;
                case Icon.Hazard:
                    GUI.Label(iconRect, hazard, style);
                    break;
                case Icon.Peace:
                    GUI.Label(iconRect, peace, style);
                    break;
                case Icon.Skull:
                    GUI.Label(iconRect, skull, style);
                    break;
                case Icon.Target:
                    GUI.Label(iconRect, target, style);
                    break;
                default:
                    break;
            }
        }

        public static TextAnchor AnchorPosition(InfoAnchor anchor)
        {
            if (anchor == InfoAnchor.Middle) { return TextAnchor.MiddleLeft; }
            else if (anchor == InfoAnchor.Bottom) { return TextAnchor.LowerLeft; }
            else return TextAnchor.UpperLeft;
        }

        public static Color GetTextColour()
        {
            Color darkModeTextColour = new Color(0.75f, 0.75f, 0.75f);
            Color normalModeTextColour = new Color(0.25f, 0.25f, 0.25f);

            return EditorGUIUtility.isProSkin ? darkModeTextColour : normalModeTextColour;
        }
    }

    public class LabelStyle
    {
        public GUIStyle guiStyle;
        public InfoAnchor anchor;
        public float xAdjust;
    }

    public enum InfoAnchor 
    { 
        Top, 
        Middle, 
        Bottom 
    }

    public enum Icon 
    { 
        None, 
        Bullet, 
        Diamond, 
        Heart, 
        Triangle, 
        Sparkle, 
        Star, 
        Sun, 
        Moon, 
        Cloud, 
        Snow, 
        Clover, 
        Flower, 
        Point, 
        Pen, 
        Hazard, 
        Peace,
        Skull,
        Target
    }
}