using System.Collections.Generic;
using System.Linq;
using Combat;
using UnityEngine;

namespace Managers.Enemies {
    /**
     * NOT IN USAGE
     */
    public class EnemyManager: MonoBehaviour {
        public static EnemyManager Instance { get; private set; } 
        
        private readonly Dictionary<string, Enemy> _enemies = new Dictionary<string, Enemy>();
        private void Awake() {
            Instance = this;
            
            var enemies = Resources.LoadAll<Enemy>("Enemies");
            Debug.Log("Enemies length: " + enemies.Length);

            foreach (var enemy in enemies) {
                Debug.Log("Add \"" + enemy.enemyName + "\" to Dic");
                _enemies.Add(enemy.enemyName, enemy);
            }
            Physics2D.IgnoreLayerCollision(6, 7);
        }

        public Enemy GetEnemy(string name) {
            if (_enemies.TryGetValue(name, out var foundedEnemy)) {
                return foundedEnemy;
            }

            Debug.LogError("Enemy \"" + name + "\" not found.");

            return _enemies.First().Value;
        }
    }
}