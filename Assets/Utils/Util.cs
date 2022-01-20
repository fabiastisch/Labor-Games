using System.Collections.Generic;
using Player;
using UnityEngine;

namespace Utils
{
    public static class Util
    {
        /**
         * Chance of Success from 0-1 for 0% to 100%
         */
        public static int GetChance(float chanceOfSuccess)
        {
            int successes = 0;

            if (chanceOfSuccess >= 1)
            {
                successes = Mathf.FloorToInt(chanceOfSuccess);
            }


            if (GetChanceBool(chanceOfSuccess - successes))
            {
                successes++;
            }

            return successes;
        }

        public static bool GetChanceBool(float chanceOfSuccess)
        {
            return Random.Range(0f, 1f) < chanceOfSuccess;
        }

        public static int GetRandomInt(int min, int max)
        {
            return Random.Range(min, max + 1);
        }

        public static float GetRandomFloat(float min, float max)
        {
            return Random.Range(min, max);
        }

        public static int GetRandomInt(int max)
        {
            return Random.Range(0, max + 1);
        }

        public static int GetAngleFromVector(Vector3 dir)
        {
            dir = dir.normalized;
            float n = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            int angle = Mathf.RoundToInt(n);

            return angle;
        }

        public static Vector2 GetRandomPosition(BoundsInt boundsInt)
        {
            return GetRandomPosition(boundsInt.xMin + 3, boundsInt.xMax - 3, boundsInt.yMin + 3, boundsInt.yMax - 3);
        }

        public static T GetRandomValue<T>(this IList<T> list)
        {
            return list[GetRandomInt(list.Count - 1)];
        }
        public static T GetRandomValue<T>(this T[] array)
        {
            return array[GetRandomInt(array.Length - 1)];
        }

        public static Vector2 GetRandomPosition(int xMin, int xMax, int yMin, int yMax)
        {
            return new Vector2(GetRandomFloat(xMin, xMax), GetRandomFloat(yMin, yMax));
        }

        public static PlayerBase GetLocalPlayer()
        {
            if (Camera.main != null)
                return Camera.main.transform.parent.GetComponent<PlayerBase>();
            Debug.LogError("Could not find local Player");
            return null;
        }
    }
}