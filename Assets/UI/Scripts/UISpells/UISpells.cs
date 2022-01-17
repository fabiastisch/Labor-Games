using System;
using System.Collections.Generic;
using System.Linq;
using Player;
using UnityEngine;
using Utils;
using Weapons.Effects;

public class UISpells : MonoBehaviour
{
    #region SingletonPattern
    private static UISpells instance;

    public static UISpells Instance
    {
        get
        {
            if (!instance)
            {
                throw new Exception("UISpells Instance does not Exist");
            }

            return instance;
        }
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Debug.LogWarning("Instance already exist.");
            Destroy(gameObject);
        }

        //DontDestroyOnLoad(gameObject);
    }
    #endregion

    private List<SpellCaster> spellCasters = new List<SpellCaster>();

    [SerializeField] private List<UISpell> Abilities;
    [SerializeField] private List<UISpell> weaponAbilities;

    private PlayerHand _playerHand;
    private void Start()
    {
        _playerHand = Util.GetLocalPlayer().hand;

        weaponAbilities[0].LinkWeapon(_playerHand);
        weaponAbilities[1].LinkWeaponEffect(_playerHand);

    }
    public void AddSpellListAbilities(List<GameObject> spellList)
    {
        spellCasters = spellList.Select(x => x.GetComponent<SpellCaster>()).ToList();

        if (Abilities.Count != spellCasters.Count)
        {
            Debug.LogError("SpellCasters Count is not equal UI Abilities: " + Abilities.Count + " | " + spellCasters.Count);
        }

        for (var i = 0; i < Abilities.Count; i++)
        {
            Abilities[i].LinkSpell(spellCasters[i]);
        }

    }
}