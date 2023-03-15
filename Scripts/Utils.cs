using TMPro;
using UnityEngine;

namespace VictorKrogh.Games.Grid 
{

    public static class Utils
    {

        public static TextMeshPro CreateWorldText(string text, int fontSize = 40, Transform parent = null, Vector3 localPosition = default, Color color = default)
        {
            if (color == default)
            {
                color = Color.white;
            }
            var gameObject = new GameObject($"World_Text ({text})", typeof(TextMeshPro));

            var transform = gameObject.transform;
            transform.SetParent(parent, false);
            transform.localPosition = localPosition;

            var textMesh = gameObject.GetComponent<TextMeshPro>();
            textMesh.alignment = TextAlignmentOptions.Center;
            textMesh.text = text;
            textMesh.fontSize = fontSize;
            textMesh.color = color;

            return textMesh;
        }

    }

}