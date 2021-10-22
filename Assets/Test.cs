using System.Collections;
using System.Collections.Generic;
using UI.CombatText;
using UnityEngine;

public class Test : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        DamagePopup.Create(Vector2.zero, 300,false);
    }

    // Update is called once per frame
    void Update()
    {
    }
}