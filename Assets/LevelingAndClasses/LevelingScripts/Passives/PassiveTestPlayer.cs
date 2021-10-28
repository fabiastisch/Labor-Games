using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class PassiveTestPlayer : MonoBehaviour
{
    
    public static PassiveTestPlayer Instance { get; private set; }
    //BaseValues
    [SerializeField] public float strength = 10;
    [SerializeField] public float MaxHp = 10;
    [SerializeField] public float magicPower = 10;
    [SerializeField] public float agillity = 10;
    [SerializeField] public float charisma = 10;
    [SerializeField] public float armor = 10;
    [SerializeField] public float magicresist = 10;
    [SerializeField] public float totalDamageReduction = 10;
    [SerializeField] public float poisenresist = 10;
    [SerializeField] public float thunderresist = 10;
    [SerializeField] public float frostresist = 10;
    [SerializeField] public float fireresist = 10;
    [SerializeField] public float shadowresist  = 10;
    
    
    
    [SerializeField] public float criticalChance  = 0;
    [SerializeField] public float attackspeed  = 1;
    [SerializeField] public float spellCoolDownReduction  = 0;
    
    
    //ActualStatus
    [SerializeField] public float ActualHP  = 5;

    void Awake()
    {
        Instance = this;
    }
    public void GetStats()
    {
        Debug.Log("Strength" + " = " +strength );
        Debug.Log("MaxHP" + " = " +MaxHp );
        Debug.Log("MagicPower" + " = " +magicPower );
        Debug.Log("Agillity" + " = " +agillity );
        Debug.Log("Charisma" + " = " +charisma );
        Debug.Log("Armor" + " = " +armor );
        Debug.Log("Magicresist" + " = " +magicresist );
        Debug.Log("Total Damage Reduction" + " = " +totalDamageReduction );
        Debug.Log("Poisenresist" + " = " +poisenresist );
        Debug.Log("Thunderresist" + " = " +thunderresist );
        Debug.Log("FrostResist" + " = " +frostresist );
        Debug.Log("FireResist" + " = " +fireresist );
        Debug.Log("Shadowresist" + " = " +shadowresist );
        Debug.Log("ActualHP" + " = " +ActualHP );
        Debug.Log("Attackspeed" + " = " +attackspeed );
        Debug.Log("CriticalChance" + " = " +criticalChance );
        Debug.Log("spellCoolDownReduction" + " = " +spellCoolDownReduction );
    }
    
    
    


}
