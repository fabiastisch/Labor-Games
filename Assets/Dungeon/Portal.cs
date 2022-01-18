using System;
using UnityEngine;
using Utils.SceneLoader;

namespace Dungeon
{
    public class Portal : MonoBehaviour
    {
        public string nextScene = "TempDungeon";
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (!other.CompareTag("Player")) return;
            //Debug.Log("OnTrigger " + other.gameObject);
            SceneLoader.instance.LoadSceneWithPlayer(nextScene);
        }
    }
}