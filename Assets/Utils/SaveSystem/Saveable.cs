using System;
using System.Collections.Generic;
using UnityEngine;

namespace Utils.SaveSystem
{
    public class Saveable : MonoBehaviour
    {
        [SerializeField] private string id = string.Empty;

        public string Id => id;

        [ContextMenu("Generate ID")]
        private void GenerateId() => id = Guid.NewGuid().ToString();

        public object CaptureState()
        {
            var state = new Dictionary<string, object>();
            foreach (var saveable in GetComponents<ISaveable>())
            {
                state[saveable.GetType().ToString()] = saveable.CaptureState();
            }

            return state;
        }

        public void RestoreState(object state)
        {
            var stateDic = (Dictionary<string, object>) state;

            foreach (var saveable in GetComponents<ISaveable>())
            {
                string type = saveable.GetType().ToString();

                if (stateDic.TryGetValue(type, out object value))
                {
                    saveable.RestoreState(value);
                }
            }
        }
    }
}