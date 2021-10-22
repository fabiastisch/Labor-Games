using System;
using UnityEngine;

namespace UI.CombatText
{
    public class CombatText : MonoBehaviour
    {
        #region SingletonPattern

        private static CombatText instance;

        public static CombatText Instance
        {
            get
            {
                if (!instance)
                {
                    Debug.Log("Create new Instance of CombatText");
                    instance = new GameObject("MyClassContainer").AddComponent<CombatText>();
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
        }

        #endregion

        [SerializeField] private Color color;
        [SerializeField] private GameObject text;
        private Canvas canvas;

        private void Start()
        {
            canvas = GetComponent<Canvas>();
        }

        public void ShowText(string text)
        {
        
        }
    }
}