using Combat;
using Dungeon;
using Dungeon.DungeonGeneration;
using UnityEngine;
using Utils.SceneLoader;

public class Boss : MonoBehaviour
{
    private Enemy _enemy;
    // Start is called before the first frame update
    void Start()
    {
        _enemy = GetComponent<Enemy>();
        PlayerUICanvas.Instance.bossBar.LinkToBoss(_enemy);
        _enemy.OnDeath += OnBossDeath;
    }
    private void OnBossDeath(Combat.Character obj)
    {
        DungeonGenerator.Instance.portal.GetComponent<Portal>().nextScene = "Hub";
    }

    // Update is called once per frame
    void Update()
    {

    }
}