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
        HitSpell,
        CastSpell,
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
        // Util.GetLocalPlayer().OnPlayerMoves += OnOnPlayerMoves;
        // Util.GetLocalPlayer().OnPlayerMakeACrit += OnOnPlayerMakeACrit;
        // Util.GetLocalPlayer().OnPlayerTakeDamage += OnOnPlayerTakeDamage;
        // Util.GetLocalPlayer().OnPlayerCastSpell += OnOnPlayerCastSpell;
        Util.GetLocalPlayer().OnPlayerHitSpell += OnOnPlayerHitSpell;
        Combat.Character.OnEntityDies += CharacterOnOnEntityDies;
    }

    private void OnOnPlayerHitSpell(GameObject obj)
    {
        if (conditionType == LevelPassiveConditionType.HitSpell)
        {
            _levelPassiveListChecker.ConditionActivation(obj);
        }
    }


    private void OnOnPlayerCastSpell()
    {
        if (conditionType == LevelPassiveConditionType.CastSpell)
        {
            _levelPassiveListChecker.ConditionActivation(null);
        }
    }

    private void OnOnPlayerTakeDamage(Enemy arg1, DamageType arg2, float arg3, bool arg4)
    {
        if (conditionType == LevelPassiveConditionType.RecievedDmg)
        {
            _levelPassiveListChecker.ConditionActivation(null);
        }
    }

    //I have to Check if comabt Char was Player
    private void CharacterOnOnEntityDies(Combat.Character obj)
    {
        if (conditionType == LevelPassiveConditionType.KilledEnemy)
        {
            if (obj.Equals(_playerBase))
            {
                _levelPassiveListChecker.ConditionActivation(null);
            }
        }
    }

    private void OnOnPlayerMakeACrit()
    {
        if (conditionType == LevelPassiveConditionType.DidCrit)
        {
            _levelPassiveListChecker.ConditionActivation(null);
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
                    _levelPassiveListChecker.ConditionActivation(null);
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
        else if (type == LevelPassiveConditionType.HitSpell)
        {
            conditionType = LevelPassiveConditionType.HitSpell;
            conditionDuration = false;
        }
        else if (type == LevelPassiveConditionType.CastSpell)
        {
            conditionType = LevelPassiveConditionType.CastSpell;
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
