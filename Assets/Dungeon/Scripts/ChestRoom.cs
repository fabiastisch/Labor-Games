using Dungeon.Spikes;
using UnityEngine;

namespace Dungeon.Scripts
{
    public class ChestRoom : MonoBehaviour
    {
        [SerializeField] private GameObject pTrap;
        [SerializeField] private GameObject pChest;

        [SerializeField] private float offsetXLeft = 2f;
        [SerializeField] private float offsetXRight = 1f;
        [SerializeField] private float offsetYTop = 2f;
        [SerializeField] private float offsetYBot = 1f;

        private void Start()
        {
            Generate();
        }

        private void Generate()
        {
            var position = transform.position;
            Instantiate(pChest, position, Quaternion.identity, transform);

            int maxX = 5;
            int maxY = 5;

            float startDelay = 0f;

            for (int i = (int) position.y - maxY; i <= position.y + maxY; i += 2)
            {
                for (int j = (int) position.x - maxX; j <= position.x + maxX; j += 2)
                {
                    var offsetY = i < position.y ? offsetYBot : offsetYTop;
                    var offsetX = j < position.x ? offsetXLeft : offsetXRight;
                    if (Mathf.Abs(i - position.y) <= offsetY && Mathf.Abs(j - position.x) <= offsetX)
                    {
                        continue;
                    }


                    GameObject gTrap = Instantiate(pTrap, new Vector3(j, i, position.z), Quaternion.identity, transform);
                    gTrap.GetComponent<ArrowTrap>().startDelay = startDelay;
                    Debug.Log(startDelay);
                    startDelay += 0.2f;
                }
            }
            /*
            for (int i = (int) position.y + offsetY; i < position.y + maxY; i++)
            {
                Instantiate(pTrap, new Vector3(position.x, i, position.z), Quaternion.identity, transform);
            }
            for (int i = (int) position.y - maxY; i < position.y - offsetY; i++)
            {
                Instantiate(pTrap, new Vector3(position.x, i, position.z), Quaternion.identity, transform);
            }

            for (int i = (int) position.x + offsetX; i < position.x + maxX; i++)
            {
                Instantiate(pTrap, new Vector3(i, position.y, position.z), Quaternion.identity, transform);
            }

            for (int i = (int) position.x - maxX; i < position.x - offsetX; i++)
            {
                Instantiate(pTrap, new Vector3(i, position.y, position.z), Quaternion.identity, transform);
            }
            */
        }
    }
}