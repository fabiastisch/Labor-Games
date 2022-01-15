using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Utils;

[CreateAssetMenu(menuName = "ScriptableObject/Spell/AuraEffectSelfDestroyAfterActiveTime")]
public class AuraEffectSelfDestroyAfterActiveTime : Spell
{
    [SerializeField] private Vector3 playerPosition;

    private List<GameObject> collection;
    
    // [SerializeField] private Animation CastAnimation;
    

    public override void Activation(GameObject parent)
    {
        playerPosition = Util.GetLocalPlayer().transform.position;
        AreaAttack(parent);
    }
    
    public override void BeginCooldown(GameObject parent)
    {
        if (!collection.Any())
        {
            return;
        }

        for (int counter = collection.Count - 1; counter >= 0; counter--)
        {
            if (collection[counter] != null)
            {
                GameObject other = collection[counter].gameObject;
                
                Destroy(other.gameObject);
            }
        }
    }

    void AreaAttack(GameObject parent)
    {
        //Debug.Log("Cast AreaAttack");
        GameObject projectile = Instantiate(magicProjectile, playerPosition, Quaternion.identity);
        projectile.transform.parent = Util.GetLocalPlayer().transform;
        collection.Add(projectile);
    }
    
    public override void Removed(GameObject parent)
    {
        if (!collection.Any())
        {
            return;
        }

        for (int counter = collection.Count - 1; counter >= 0; counter--)
        {
            if (collection[counter] != null)
            {
                GameObject other = collection[counter].gameObject;
                
                Destroy(other.gameObject);
            }
        }
    }
}