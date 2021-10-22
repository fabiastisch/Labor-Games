﻿using UnityEngine;

namespace Utils
{
    public class GameAssets : MonoBehaviour
    {
        private static GameAssets instance;

        public static GameAssets Instance
        {
            get
            {
                if (instance == null) instance = Instantiate(Resources.Load<GameAssets>("GameAssets"));
                return instance;
            }
        }

        public Transform damagePopupPrefab;
        
        
    }
}