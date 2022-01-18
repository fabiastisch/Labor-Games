using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Utils;

[CreateAssetMenuAttribute( menuName = "LevelPassive/Single/Abi/AoeCaster")]
public class Abi2 : LevelPassive
{
    [SerializeField] private GameObject magicProjectile;
    private List<GameObject> collection = new List<GameObject>();

    [SerializeField] [Range(0f,1f)] private float chance;
    //todo set this somehow up Aoe after Spellcast / Dmg
    // Start is called before the first frame update

    public override void Activation(GameObject parent)
    {
        AreaAttack(parent);
    }

    
    
    void AreaAttack(GameObject parent)
    {
        if (collection.Count <= 15)
        {
            if (Util.GetChanceBool(chance))
            {
                GameObject aoe = Instantiate(magicProjectile, parent.transform.position, Quaternion.identity);
                collection.Add(aoe);
            }
        }
        for (int counter = collection.Count - 1; counter >= 0; counter--)
        {
            if (collection[counter] == null)
            {
                collection.Remove(collection[counter]);
            }
        }
    }

    void ResetCollection()
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
