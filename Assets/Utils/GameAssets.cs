using UnityEngine;

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
        public Transform textPopupPrefab;
        public Transform globalDungeonStatePrefab;
        public Transform textUIPrefab;

        public Transform Instantiate(Transform t)
        {
            return Instantiate(t, transform);
        }
    }
}