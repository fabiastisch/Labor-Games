using UnityEngine;
namespace Player
{
    public class PlayerLevelManager : MonoBehaviour
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

        [SerializeField] private LevelSlider _levelSlider;

        private void Start()
        {
            UpdateStuff();
        }

        public void AddExp(int amount)
        {
            if (IsMaxLevel()) return;

            experience += amount;
            while (experience >= GetExpToNextLevel(currentLevel))
            {
                experience -= GetExpToNextLevel(currentLevel);
                currentLevel++;
            }
            UpdateStuff();
        }

        private void UpdateStuff()
        {
            _levelSlider.SetLevel(currentLevel);
            _levelSlider.SetValue(GetExperienceNormalized());
        }

        public int GetExpToNextLevel(int level)
        {
            return baseExpToNextLevel * level*level;
        }

        public float GetExperienceNormalized()
        {
            return (float) experience / GetExpToNextLevel(currentLevel);
        }

        public bool IsMaxLevel()
        {
            return maxLevel == currentLevel;
        }

    }
}