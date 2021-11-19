using TMPro;
using UnityEngine;
using Utils;

namespace UI.Text
{
    public class TextPopup : MonoBehaviour
    {
        private TextMeshPro textMesh;

        public static TextPopup Create(Vector2 position, Transform parent, string text)
        {
            Transform textPopup =
                Instantiate(GameAssets.Instance.textPopupPrefab, position, Quaternion.identity);
            textPopup.SetParent(parent);

            TextPopup popup = textPopup.GetComponent<TextPopup>();

            popup.Setup(text);

            return popup;
        }

        private void Awake()
        {
            textMesh = transform.GetComponent<TextMeshPro>();
        }

        private void Setup(string text)
        {
            textMesh.SetText(text);
        }

        public TextMeshPro GetTextMesh()
        {
            return textMesh;
        }
    }
}