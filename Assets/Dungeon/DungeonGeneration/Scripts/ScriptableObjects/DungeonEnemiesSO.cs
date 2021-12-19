using System.Collections.Generic;
using Combat;
using UnityEngine;
namespace Dungeon.DungeonGeneration
{
    [CreateAssetMenu(fileName = "DungeonEnemies_", menuName = "PCG/Enemies")]
    public class DungeonEnemiesSO : ScriptableObject
    {
        public List<GameObject> enemies;

        public int EnemyCount;
        
        private void OnValidate()
        {
            for (var i = 0; i < enemies.Count; i++)
            {
                if (enemies[i] &&!enemies[i].GetComponent(typeof(Enemy)))
                {
                    Debug.LogError("Enemy on Index " + i + " isn't an Enemy: " + enemies[i]);
                }
            }
        }
    }
}