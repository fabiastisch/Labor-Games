using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotDestroyable : MonoBehaviour
{
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
}
