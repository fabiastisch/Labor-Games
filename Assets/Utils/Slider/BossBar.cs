using Combat;
using UnityEngine;
public class BossBar : TextSlider
{
    private Enemy currentEnemy;
    // Start is called before the first frame update
    void Start()
    {
        SetValue(1f);
        ChangeActive(false);

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void ChangeActive(bool active)
    {
        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(active);
        }
    }
    public void LinkToBoss(Enemy enemy)
    {
        enemy.OnHealthChanged += EnemyOnOnHealthChanged;
        SetText(enemy.enemyName);
        enemy.OnDeath += EnemyOnOnDeath;
        currentEnemy = enemy;
        SetValue(enemy.GetPercentageHpSmall());
        ChangeActive(true);
    }
    private void EnemyOnOnDeath(Combat.Character obj)
    {
        currentEnemy = null;
        SetValue(1f);
        ChangeActive(false);
    }
    private void EnemyOnOnHealthChanged(float currentHealth)
    {
        SetValue(currentHealth / currentEnemy.GetMaxHealth());
    }
}