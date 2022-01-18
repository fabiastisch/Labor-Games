using Combat;
using Dungeon;
using Dungeon.DungeonGeneration;
using UnityEngine;

public class Boss : MonoBehaviour
{
    private Enemy _enemy;

    private Portal _portal;
    // Start is called before the first frame update
    void Start()
    {
        _enemy = GetComponent<Enemy>();
        PlayerUICanvas.instance.bossBar.LinkToBoss(_enemy);
        _portal = DungeonGenerator.instance.portal.GetComponent<Portal>();
        _portal.nextScene = "HubWithoutPlayer";
        _portal.gameObject.SetActive(false);
        _enemy.OnDeath += OnBossDeath;
    }
    private void OnBossDeath(Combat.Character obj)
    {
        _portal.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {

    }
}