using System;
using System.Collections.Generic;
using Combat;
using UnityEngine;
namespace Dungeon.DungeonGeneration
{
    [CreateAssetMenu(fileName = "DungeonEnemies_", menuName = "PCG/Enemies")]
    public class DungeonEnemiesSO : ScriptableObject
    {

        public List<EnemyConfig> config;

        public bool randomAdditive = false;
        public int randomAdditiveCount = 0;
        
        private void OnValidate()
        {
            for (var i = 0; i < config.Count; i++)
            {
                if (config[i].enemy &&!config[i].enemy.GetComponent(typeof(Enemy)))
                {
                    Debug.LogError("Enemy on Index " + i + " isn't an Enemy: " + config[i].enemy);
                }
            }
        }
    }
    [Serializable]
    public class EnemyConfig
    {
        public GameObject enemy;
        public int count;
    }
}