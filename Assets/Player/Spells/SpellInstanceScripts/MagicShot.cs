using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Utils;

[CreateAssetMenuAttribute(menuName = "ScriptableObject/Spell/MagicShot")]
public class MagicShot : Spell
{
    private List<GameObject> collection;
    [SerializeField] private bool destroy = true;
    
    // public float flyDuration;
    // public float speed;
    //I cant Drag a Scene Object into here so i need to initialize it in the script

    // [SerializeField] private Animation CastAnimation;
    

    public override void Activation(GameObject parent)
    {
        FireBall();
    }
    
    void FireBall()
    {
        GameObject player = Util.GetLocalPlayer().gameObject;
        
        Debug.Log("Cast Fireball");
        GameObject projectile = Instantiate(magicProjectile, player.transform.position, player.GetComponent<MouseTrack>().GetRotationToMouse());
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
                if(destroy)
                    Destroy(other.gameObject);
            }
        }
    }
    
    
}
