using System.Collections.Generic;
using System.Linq;
using Combat;
using UnityEngine;
using Utils;

[CreateAssetMenu(menuName = "ScriptableObject/Spell/AbillityCastOnPlayer")]
public class AbillityCastOnPlayer : Spell
{
    [SerializeField] private Vector3 playerPosition;

    private List<GameObject> collection;
    [SerializeField] private bool destroy = true;

    [SerializeField] private bool noRotation;
    
    // [SerializeField] private Animation CastAnimation;
    

    public override void Activation(GameObject parent)
    {
        playerPosition = Util.GetLocalPlayer().transform.position;
        AreaAttack(parent);
      

    }

    void AreaAttack(GameObject parent)
    {
        GameObject player = Util.GetLocalPlayer().gameObject;
        //Debug.Log("Cast AreaAttack");
        GameObject projectile;
        if(!noRotation)
             projectile = Instantiate(magicProjectile, player.transform.position, player.GetComponent<MouseTrack>().GetRotationToMouse());
        else
             projectile = Instantiate(magicProjectile, player.transform.position, Quaternion.identity);
        projectile.transform.parent = Util.GetLocalPlayer().transform;
        collection.Add(projectile);
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
                if(destroy)
                    Destroy(other.gameObject);
            }
        }
    }
    
}