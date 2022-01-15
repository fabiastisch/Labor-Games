using System;
using UnityEngine;

public class PlayerUICanvas : MonoBehaviour
{
    #region SingletonPattern
    private static PlayerUICanvas instance;

    public static PlayerUICanvas Instance
    {
        get
        {
            if (!instance)
            {
                throw new Exception("PlayerUICanvas Instance does not Exist");
            }

            return instance;
        }
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Debug.LogWarning("Instance already exist.");
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }
    #endregion

    public BossBar bossBar;
   
}