using System;
using UnityEngine;
using Utils;

namespace Dungeon
{
    public class Spawn : MonoBehaviour
    {
        #region SingletonPattern
        private static Spawn instance;

        public static Spawn Instance
        {
            get
            {
                if (!instance)
                {
                    Debug.Log("Create new Instance of Spawn");
                    instance = new GameObject("MyClassContainer").AddComponent<Spawn>();
                }

                return instance;
            }
        }

        private void Awake()
        {
            //Debug.Log("Spawn Awake");
            if (instance == null)
            {
                instance = this;
            }
        }
        #endregion

        private void Start()
        {
            Util.GetLocalPlayer().transform.position = transform.position;
        }

        private void OnDestroy()
        {
            //Debug.Log("Destroy Spawn");
        }
    }
}