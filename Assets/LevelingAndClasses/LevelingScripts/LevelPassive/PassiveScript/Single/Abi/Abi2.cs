using UnityEngine;
using Utils;

[CreateAssetMenuAttribute( menuName = "LevelPassive/Single/Abi/AoeCaster")]
public class Abi2 : LevelPassive
{
    [SerializeField] private GameObject magicProjectile;

    [SerializeField] [Range(0f,1f)] private float chance;
    //todo set this somehow up Aoe after Spellcast / Dmg
    // Start is called before the first frame update

    public override void Activation(GameObject parent)
    {
        AreaAttack(parent);
    }

    
    
    void AreaAttack(GameObject parent)
    {
        Debug.Log("Cast AreaAttack");
        if(Util.GetChanceBool(chance))
        Instantiate(magicProjectile, parent.transform.position, Quaternion.identity);
    }
}
