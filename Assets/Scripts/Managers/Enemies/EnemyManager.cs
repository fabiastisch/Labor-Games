using System.Collections.Generic;
using System.Linq;
using Combat;
using UnityEngine;

namespace Managers.Enemies {
    public class EnemyManager: MonoBehaviour {
        public static EnemyManager Instance { get; private set; } 


        private Dictionary<string, Enemy> _enemies = new Dictionary<string, Enemy>();
        private void Awake() {
            Instance = this;
            
            var enemies = Resources.LoadAll<Enemy>("Enemies");
            Debug.Log("Enemies length: " + enemies.Length);

            foreach (var enemy in enemies) {
                Debug.Log("Add \"" + enemy.enemyName + "\" to Dic");
                _enemies.Add(enemy.enemyName, enemy);
            }
            
        }

        public Enemy GETEnemy(string name) {
            if (_enemies.TryGetValue(name, out var foundedEnemy)) {
                return foundedEnemy;
            }

            Debug.LogError("Enemy \"" + name + "\" not found.");

            return _enemies.First().Value;
        }
    }
}