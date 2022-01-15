using System;
using UnityEngine;
using Utils.SaveSystem;
namespace Player
{
    public class PlayerLevelManager : MonoBehaviour, ISaveable
    {
        #region SingletonPattern
        private static PlayerLevelManager instance;

        public static PlayerLevelManager Instance
        {
            get
            {

                if (!instance)
                {
                    Debug.LogWarning("ExperienceManager Instance does not Exist!");
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

        public int currentLevel = 1;
        public int maxLevel;
        public int experience = 0;
        public int baseExpToNextLevel;

        [SerializeField] private TextSlider textSlider;

        public event Action<int> OnLevelChanged;
        public event Action<int> OnExperiencedChanged;

        private void Start()
        {
            UpdateLevelSlider();
            OnLevelChanged += (level) => textSlider.SetText(level.ToString());
            OnExperiencedChanged += (exp) => textSlider.SetValue(GetExperienceNormalized());
        }

        public void AddExp(int amount)
        {
            if (IsMaxLevel()) return;

            experience += amount;
            while (!IsMaxLevel() && experience >= GetExpToNextLevel(currentLevel))
            {
                experience -= GetExpToNextLevel(currentLevel);
                currentLevel++;
                OnLevelChanged?.Invoke(currentLevel);
            }
            OnExperiencedChanged?.Invoke(experience);
        }

        private void UpdateLevelSlider()
        {
            textSlider.SetText(currentLevel.ToString());
            textSlider.SetValue(GetExperienceNormalized());
        }

        public int GetExpToNextLevel(int level)
        {
            return baseExpToNextLevel * level * level;
        }

        public float GetExperienceNormalized()
        {
            return (float) experience / GetExpToNextLevel(currentLevel);
        }

        public bool IsMaxLevel()
        {
            return maxLevel == currentLevel;
        }

        #region Saveable
        public object CaptureState()
        {
            return new PlayerLevelData(experience, currentLevel);
        }
        public void RestoreState(object state)
        {
            PlayerLevelData data = (PlayerLevelData) state;
            experience = data.experience;
            currentLevel = data.level;
            UpdateLevelSlider();
        }
        #endregion
    }

    [System.Serializable]
    public class PlayerLevelData
    {
        public int experience;
        public int level;
        public PlayerLevelData(int experience, int level)
        {
            this.experience = experience;
            this.level = level;
        }
    }
}