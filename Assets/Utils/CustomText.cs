using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CustomText : MonoBehaviour
{
    private TMP_Text _text;

    private void Awake()
    {
        _text = GetComponent<TMP_Text>();
    }
    // Start is called before the first frame update
    void Start()
    {
        _text.text = "";
        SceneManager.sceneLoaded += OnSceneLoaded;
    }
    private void OnSceneLoaded(Scene arg0, LoadSceneMode arg1)
    {
        _text.text = "";
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void SetText(string text)
    {
        _text.text = text;
    }
}