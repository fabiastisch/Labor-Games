using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Utils;

public class TextUI : MonoBehaviour
{
    private TMP_Text _text;
    public static TextUI Create(Vector2 position, string text, Transform parent = null)
    {
        Debug.Log("Create - " + text);
        Transform textUI =
            Instantiate(GameAssets.Instance.textUIPrefab, position, Quaternion.identity);
        if (parent) textUI.SetParent(parent);
        textUI.SetParent(Util.GetLocalPlayer().playerCanvas.transform);

        TextUI popup = textUI.GetComponent<TextUI>();

        popup.Setup(text);

        return popup;
    }

    private void Awake()
    {
        _text = transform.GetComponentInChildren<TMP_Text>();
    }

    private void Setup(string text)
    {
        if (text == "")
        {
            _text.SetText("Empty");
        }
        _text.SetText(text);
        //_text.fontSize = 9f;
    }

    public TMP_Text GetText()
    {
        return _text;
    }
}