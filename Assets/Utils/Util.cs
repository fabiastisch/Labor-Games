using UnityEngine;

namespace Utils
{
    public static class Util
    {
        public static int GetChance(float chanceOfSuccess)
        {
            int successes = 0;

            if (chanceOfSuccess >= 1)
            {
                successes = Mathf.FloorToInt(chanceOfSuccess);
            }

            if (Random.Range(0, 100) < (chanceOfSuccess - successes))
            {
                successes++;
            }

            return successes;
        }

        public static int GetAngleFromVector(Vector3 dir)
        {
            dir = dir.normalized;
            float n = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            int angle = Mathf.RoundToInt(n);

            return angle;
        }
    }
}