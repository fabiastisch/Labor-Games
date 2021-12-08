using UnityEngine;

namespace Utils {
    public static class Util {
        public static int GetChance(float chanceOfSuccess) {
            int successes = 0;

            if (chanceOfSuccess >= 1) {
                successes = Mathf.FloorToInt(chanceOfSuccess);
            }

            if (Random.Range(0, 100) < (chanceOfSuccess - successes)) {
                successes++;
            }

            return successes;
        }

        public static int GetRandomInt(int min, int max) {
            return Random.Range(min, max + 1);
        }

        public static int GetRandomInt(int max) {
            return Random.Range(0, max + 1);
        }

        public static int GetAngleFromVector(Vector3 dir) {
            dir = dir.normalized;
            float n = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            int angle = Mathf.RoundToInt(n);

            return angle;
        }

        public static Vector2 GetRandomPosition(BoundsInt boundsInt) {
            return GetRandomPosition(boundsInt.xMin+2, boundsInt.xMax-2, boundsInt.yMin+2, boundsInt.yMax-2);
        }

        public static Vector2 GetRandomPosition(int xMin, int xMax, int yMin, int yMax) {
            return new Vector2(GetRandomInt(xMin, xMax), GetRandomInt(yMin, yMax));
        }
    }
}