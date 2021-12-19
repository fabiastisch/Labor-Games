using UnityEngine;
public class LevelPassiveListChecker : MonoBehaviour
    {
        public LevelPassive levelPassive;
        private PassiveSlot.PassiveState state = PassiveSlot.PassiveState.ready;

        public LevelPassiveTime timer;
        
        //Adds TimeFunction
        //private TimeModul timeModul = null;
        
        public bool used;
        public bool timeactivated;
        private bool _isLevelPassiveNotNull;
        
        private float activeTime;

        private void Start()
        {
            _isLevelPassiveNotNull = levelPassive != null;
            timer = gameObject.AddComponent<LevelPassiveTime>();
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
                        //If Condition wait for Trigger, if it triggers activate it
                        case LevelPassive.LevelPassiveType.Condition:
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

        }

        
        private void SetStateReady()
        {
            state = PassiveSlot.PassiveState.ready;
        }
        
        //Add Passive
        public void addLevelPassive(LevelPassive lp)
        {
            timeactivated = false;
            levelPassive = lp;
            _isLevelPassiveNotNull = true;
            used = false;
            //If Condition sets the Functions
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
        }

        public void TimeActivation()
        {
            levelPassive.Activation(gameObject);
        }
    
    }