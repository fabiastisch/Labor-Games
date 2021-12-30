using UnityEngine;
public class LevelPassiveListChecker : MonoBehaviour
    {
        public LevelPassive levelPassive;
        private PassiveSlot.PassiveState state = PassiveSlot.PassiveState.ready;

        public LevelPassiveTime timer;
        public LevelPassiveCondition condition;
        
        //Adds TimeFunction
        //private TimeModul timeModul = null;
        
        public bool used = false;
        public bool timeactivated;
        private bool _isLevelPassiveNotNull;

        private bool hasActiveTime;
        private bool activTimeActivated;
        
        private float activeMaxTime;

        private float activeTimer;
        private void Start()
        {
            _isLevelPassiveNotNull = levelPassive != null;
            timer = gameObject.GetComponent<LevelPassiveTime>();
            condition = gameObject.GetComponent<LevelPassiveCondition>();
        }

        void Update()
        {
            if (!used)
            {
                if (_isLevelPassiveNotNull)
                {
                    switch (levelPassive.levelPassiveType)
                    {
                        //If SingleTime use it once and then Disable it
                        case LevelPassive.LevelPassiveType.SingleTime:
                            used = true;
                            levelPassive.Activation(gameObject);
                            break;
                        //If Repeat case Activate it after Time 
                        case LevelPassive.LevelPassiveType.Repeat:
                            if (!timeactivated)
                            {
                                timeactivated = true;
                                timer.SetMaxCooldown(levelPassive.cooldownMaxTime);
                                timer.SetTimer();
                                timer.TimeReset();
                            }
                            break;
                    }
                }
            }

            //if Passive is only active for a Time
            if (hasActiveTime)
            {
                if (activTimeActivated)
                {
                    //use time do Subtract things
                    activeTimer -= Time.deltaTime;
                    //after Time is over do something and restart Timer
                    if (activeTimer <= 0f)
                    {
                        levelPassive.BeginCooldown(gameObject);
                        activeTimer = activeMaxTime;
                        activTimeActivated = false;
                    }
                }
            }
            
            

        }

        
        private void SetStateReady()
        {
            state = PassiveSlot.PassiveState.ready;
        }
        
        //Add Passive
        public void AddLevelPassive(LevelPassive lp)
        {
            timeactivated = false;
            levelPassive = lp;
            _isLevelPassiveNotNull = true;
            used = false;

            //Set Conditions
            if (levelPassive.levelPassiveType == LevelPassive.LevelPassiveType.Condition && levelPassive.conditionType != LevelPassiveCondition.LevelPassiveConditionType.None)
            {
                condition.SetConditions(levelPassive.conditionTime, levelPassive.conditionTime);
                condition.SetConditionType(levelPassive.conditionType);
            }
            else
            {
                condition.NoCondition();
            }
            
            //Set Things if it has a Active Time
            if (levelPassive.hasActiveTime)
            {
                hasActiveTime = true;
                activeTimer = levelPassive.activeMaxTime;
                activeMaxTime = levelPassive.activeMaxTime;
                activTimeActivated = false;
            }
            else
            {
                hasActiveTime = false;
                activeTimer = 0;
                activeMaxTime = 0;
                activTimeActivated = false;
            }
            
        }
        
        //Removes Passive
        public void RemovePassive()
        {
            
            levelPassive.Removed(gameObject);
            used = false;
            
            levelPassive = null;
            _isLevelPassiveNotNull = false;
            
            
            timer.RemoveTimer();
            timeactivated = false;
            
            condition.NoCondition();
            
            activTimeActivated = false;
            hasActiveTime = false;
        }

        //For Time Activation
        public void TimeActivation()
        {
            levelPassive.Activation(gameObject);
            if (hasActiveTime)
            {
                activTimeActivated = true;
            }
        }
        
        //For Condition Activation
        public void ConditionActivation(GameObject obj)
        {
            if (levelPassive.conditionType == LevelPassiveCondition.LevelPassiveConditionType.HitSpell)
            {
                levelPassive.Activation(obj);
            }
            else
            {
                levelPassive.Activation(gameObject);
                if (hasActiveTime)
                {
                    activTimeActivated = true;
                }
            }
        }
    
    }