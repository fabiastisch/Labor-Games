using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObject/Spell/AuraEffect")]
public class AuraEffect : Spell
{
    [SerializeField] private Vector3 playerPosition;

    private List<GameObject> collection;
    
    // [SerializeField] private Animation CastAnimation;
    

    public override void Activation(GameObject parent)
    {
        playerPosition = parent.transform.position;
        AreaAttack(parent);
      

    }

    void AreaAttack(GameObject parent)
    {
        Debug.Log("Cast AreaAttack");
        GameObject projectile = Instantiate(magicProjectile, playerPosition, Quaternion.identity);
        projectile.transform.parent = parent.transform;
        collection.Add(projectile);
    }
    
}
