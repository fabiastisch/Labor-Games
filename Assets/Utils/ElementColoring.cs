using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Combat;


namespace Utils
{
    public class ElementColoring : MonoBehaviour
    {
        public static Color FireColor = Color.red;
        public static Color FrostColor = Color.cyan;
        public static Color LigthningColor = Color.yellow;
        public static Color PhysicalColor = Color.gray;
        public static Color PoisonColor = Color.green;
        public static Color MagicalColor = Color.blue;
        public static Color ShadowColor = Color.black;
        public static void RecolorSpriteByDamagetyp(SpriteRenderer sphereSprite, DamageType type)
        {
            switch (type)
            {
                case DamageType.Fire:
                    sphereSprite.color = FireColor;
                    return;
                case DamageType.Frost:
                    sphereSprite.color = FrostColor;
                    return;
                case DamageType.Lightning:
                    sphereSprite.color = LigthningColor;
                    return;
                case DamageType.Physical:
                    sphereSprite.color = PhysicalColor;
                    return;
                case DamageType.Poison:
                    sphereSprite.color = PoisonColor;
                    return;
                case DamageType.Magical:
                    sphereSprite.color = MagicalColor;
                    return;
                case DamageType.Shadow:
                    sphereSprite.color = ShadowColor;
                    return;
            }
        }
    }
}
