using UnityEngine;
using Utils.SceneLoader;

namespace Dungeon
{
    public class Portal : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D other)
        {
            //Debug.Log("OnTrigger " + other.gameObject);
            SceneLoader.Instance.LoadSceneWithPlayer("TempDungeon");
        }
    }
}