
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenuAttribute(menuName = "ScriptableObject/Spell")]
public class Spell : ScriptableObject
{ 
    //Basic Class for Spell
    [SerializeField] public GameObject magicProjectile;
  
    public new string name;
    public SpellType spellType;

    public float cooldownMax;
    public float activeTimeMax;
    
    private List<GameObject> projectileList;

    public ClassEnum.Classes classType = ClassEnum.Classes.None;

    public SkillsAndPassivesType typeForUI = SkillsAndPassivesType.None;

    public Sprite abitllityIcon;
    
    

    public enum SpellType
    {
        Aura,
        Aoe,
        Projectile,
        OnEnemy,
        Buff
    }
    
    /**
     * Activate the Effect
     */
    public virtual void Activation(GameObject parent)
    {
    }
   
    /**
     * Negative Effect or Reset of the Effect
     */
    public virtual void BeginCooldown(GameObject parent)
    {
    }
    
    /**
     * Remove the effect or destroy it
     */
    public virtual void Removed(GameObject parent)
    {
    }
    
    /**
     * Reset if the Cooldown has a Negative Effect
     */
    public virtual void Reset(GameObject parent)
    {
    }
    
    public virtual void DestroyMe()
    {
        foreach (var item in projectileList)
        {
          Destroy(item);
        }
        
    }
    
    
}
