using System.Collections;
using System.Collections.Generic;
using Combat;
using UnityEngine;

public class Boss : MonoBehaviour
{
    private Enemy _enemy;
    // Start is called before the first frame update
    void Start()
    {
        _enemy = GetComponent<Enemy>();
        PlayerUICanvas.Instance.bossBar.LinkToBoss(_enemy);
    }

    // Update is called once per frame
    void Update()
    {

    }
}