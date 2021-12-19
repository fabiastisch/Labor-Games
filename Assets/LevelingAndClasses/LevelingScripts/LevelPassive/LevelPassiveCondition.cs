using Combat;
using Player;
using UnityEngine;
using Utils;

public class LevelPassiveCondition : MonoBehaviour
{
    
    public enum LevelPassiveConditionType
    {
        DidCrit,
        Movement,
        KilledEnemy,
        RecievedDmg,
        None
    }
    
    private LevelPassiveConditionType conditionType;

    private float conditionDurationTimer;

    private float conditionMaxTime;

    private bool conditionDuration = false;
    private bool triggered = false;
    
    private LevelPassiveListChecker _levelPassiveListChecker;
    private PlayerBase _playerBase;


    private void Start()
    {
        _playerBase = Util.GetLocalPlayer();
        _levelPassiveListChecker = gameObject.GetComponent<LevelPassiveListChecker>();
        Util.GetLocalPlayer().OnPlayerMoves += OnOnPlayerMoves;
        Util.GetLocalPlayer().OnPlayerMakeACrit += OnOnPlayerMakeACrit;
        Util.GetLocalPlayer().OnPlayerTakeDamage += OnOnPlayerTakeDamage;
        Combat.Character.OnEntityDies += CharacterOnOnEntityDies;
    }

    private void OnOnPlayerTakeDamage(Enemy arg1, DamageType arg2, float arg3, bool arg4)
    {
        if (conditionType == LevelPassiveConditionType.RecievedDmg)
        {
            _levelPassiveListChecker.ConditionActivation();
        }
    }

    //I have to Check if comabt Char was Player
    private void CharacterOnOnEntityDies(Combat.Character obj)
    {
        if (conditionType == LevelPassiveConditionType.KilledEnemy)
        {
            if (obj.Equals(_playerBase))
            {
                _levelPassiveListChecker.ConditionActivation();
            }
        }
    }

    private void OnOnPlayerMakeACrit()
    {
        if (conditionType == LevelPassiveConditionType.DidCrit)
        {
            _levelPassiveListChecker.ConditionActivation();
        }
    }

    //true move
    //false doesnt MOOOOOVE
    private void OnOnPlayerMoves(bool moves)
    {
        if (conditionType == LevelPassiveConditionType.Movement)
        {
            if (moves)
            {
                TimeConditionActivated();
            }
            else
            {
                TimeConditionReset();
            }
        }
    }

    private void TimeConditionActivated()
    {
        triggered = true;
    }
    
    private void TimeConditionReset()
    {
        triggered = false;
        ResetConditionTime();
    }
    
    
    void Update()
    {
        if (conditionDuration)
        {
            if (triggered)
            {
                conditionDurationTimer -= Time.deltaTime;
                //after Time is over do something and restart Timer
                if (conditionDurationTimer <= 0f)
                {
                    _levelPassiveListChecker.ConditionActivation();
                    ResetConditionTime();
                }
            }
        }
    }

    public void ResetConditionTime()
    {
        conditionDurationTimer = conditionMaxTime;
    }

    public void SetConditionType(LevelPassiveConditionType type)
    {

        if (type == LevelPassiveConditionType.Movement)
        {
            conditionType = LevelPassiveConditionType.Movement;
            conditionDuration = true;
        }
        else if (type == LevelPassiveConditionType.DidCrit)
        {
            conditionType = LevelPassiveConditionType.DidCrit;
            conditionDuration = false;
        }
        else if (type == LevelPassiveConditionType.KilledEnemy)
        {
            conditionType = LevelPassiveConditionType.KilledEnemy;
            conditionDuration = false;
        }
        else if (type == LevelPassiveConditionType.RecievedDmg)
        {
            conditionType = LevelPassiveConditionType.RecievedDmg;
            conditionDuration = false;
        }
    }
    
    public void NoCondition()
    {
        conditionType = LevelPassiveConditionType.None;
        conditionDuration = false;
    }

    public void SetConditions(float conMaxTime, float conDurationTimer)
    {
        conditionDurationTimer = conDurationTimer;
        conditionMaxTime = conMaxTime;
    }
    
    
    
    
    
    
}
