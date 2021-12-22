using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;

[CreateAssetMenu(menuName = "Abillitys/AuraEffect")]
public class AuraEffect : Passive
{
    [SerializeField] private GameObject magicProjectile;
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

    // public override void Removed(GameObject parent)
    // {
    //     foreach (var item in collection)
    //     {
    //         item.GetComponent<MagicAoeExplosion>().DestroyMe();
    //     }
    // }
}
