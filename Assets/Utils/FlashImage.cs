using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using Utils;

public class FlashImage : MonoBehaviour
{
    private Image _image;
    private Coroutine _coroutine;
    [SerializeField] private Color flashColor = Color.white;
    private void Awake()
    {
        _image = GetComponent<Image>();
    }

    private void Start()
    {
        _image.color = new Color(0, 0, 0, 0);
        Util.GetLocalPlayer().OnPlayerTakeDamage += (enemy, type, arg3, arg4) => StartFlash(0.08f, 0.6f);
    }

    public void StartFlash(float time, float alpha)
    {

        _image.color = flashColor;

        alpha = Mathf.Clamp01(alpha);

        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
        }
        _coroutine = StartCoroutine(Flash(time, alpha));
    }
    IEnumerator Flash(float time, float alpha)
    {
        float flashHalf = time / 2;
        for (float i = 0; i < flashHalf; i += Time.deltaTime)
        {
            Color color = _image.color;
            color.a = Mathf.Lerp(0, alpha, i / flashHalf);
            _image.color = color;

            yield return null;
        }

        for (float i = 0; i < flashHalf; i += Time.deltaTime)
        {
            Color color = _image.color;
            color.a = Mathf.Lerp(alpha, 0, i / flashHalf);
            _image.color = color;

            yield return null;
        }

        // transparent
        _image.color = new Color(0, 0, 0, 0);


    }
}