using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SpellHoldChecker : MonoBehaviour
{
    [Header("Spell Active")] [SerializeField]
    private List<GameObject> spellList = new List<GameObject>();
    
    
    public static SpellHoldChecker Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    public void AddSpell(GameObject spellObject)
    {

        spellList[0].GetComponent<SpellCaster>().spell = spellObject.GetComponent<Spell>();
    }
    
    public void RemoveSpell()
    {
        spellList[0].GetComponent<SpellCaster>().spell = null;
    }

    /**
     * Between 0 and 1
     */
    public void ReduceCooldown(float percentage)
    {
        foreach (var spellHolder in spellList)
        {
            spellHolder.GetComponent<SpellCaster>().RemoveFromActivePercentage(percentage);
        }
    }
    
    public void AddCooldown(float percentage)
    {
        foreach (var spellHolder in spellList)
        {
            spellHolder.GetComponent<SpellCaster>().AddPrecentageToTimer(percentage);
        }
    }
    
    
    
    
    
    
    
}
