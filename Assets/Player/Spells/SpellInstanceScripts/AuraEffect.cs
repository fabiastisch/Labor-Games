using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor.SceneManagement;
using UnityEngine;
using Utils;

[CreateAssetMenu(menuName = "ScriptableObject/Spell/AuraEffect")]
public class AuraEffect : Spell
{
    [SerializeField] private Vector3 playerPosition;

    private List<GameObject> collection;
    
    // [SerializeField] private Animation CastAnimation;
    

    public override void Activation(GameObject parent)
    {
        playerPosition = Util.GetLocalPlayer().transform.position;
        AreaAttack(parent);
      

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
