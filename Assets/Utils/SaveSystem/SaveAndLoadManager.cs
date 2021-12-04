using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

namespace Utils.SaveSystem
{
    public class SaveAndLoadManager : MonoBehaviour
    {
        #region SingletonPattern

        private static SaveAndLoadManager instance;

        public static SaveAndLoadManager Instance
        {
            get
            {
                if (!instance)
                {
                    throw new Exception("SaveAndLoadManager Instance does not Exist");
                }

                return instance;
            }
        }

        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
            }
            else if (instance != this)
            {
                Debug.LogWarning("Instance already exist.");
                Destroy(gameObject);
            }

            DontDestroyOnLoad(gameObject);
        }

        #endregion

        /**
         * TODO: Add multiple files for diff classes
         */
        private string SavePath => $"{Application.persistentDataPath}/save.wtf";


        [ContextMenu("Save")]
        public void Save()
        {
            Debug.Log(SavePath);
            var state = LoadFile();
            CaptureState(state);
            SaveFile(state);
        }

        [ContextMenu("Load")]
        public void Load()
        {
            var state = LoadFile();
            RestoreState(state);
        }

        private void SaveFile(object state)
        {
            Debug.Log("Save File");
            using (var stream = File.Open(SavePath, FileMode.Create))
            {
                var formatter = GetBinaryFormatter();
                formatter.Serialize(stream, state);
            }
        }

        private Dictionary<string, object> LoadFile()
        {
            if (!File.Exists(SavePath))
            {
                return new Dictionary<string, object>();
            }

            using (FileStream stream = File.Open(SavePath, FileMode.Open))
            {
                var formatter = GetBinaryFormatter();
                return (Dictionary<string, object>) formatter.Deserialize(stream);
            }
        }

        private void CaptureState(Dictionary<string, object> state)
        {
            foreach (var saveable in FindObjectsOfType<Saveable>())
            {
                state[saveable.Id] = saveable.CaptureState();
            }
        }

        private void RestoreState(Dictionary<string, object> state)
        {
            foreach (var saveable in FindObjectsOfType<Saveable>())
            {
                if (state.TryGetValue(saveable.Id, out object value))
                {
                    saveable.RestoreState(value);
                }
            }
        }

        public BinaryFormatter GetBinaryFormatter()
        {
            BinaryFormatter formatter = new BinaryFormatter();
            SurrogateSelector selector = new SurrogateSelector();
            Vector3SerializationSurrogate vector3SerializationSurrogate = new Vector3SerializationSurrogate();

            selector.AddSurrogate(typeof(Vector3), new StreamingContext(StreamingContextStates.All),
                vector3SerializationSurrogate);

            formatter.SurrogateSelector = selector;

            return formatter;
        }
    }
}