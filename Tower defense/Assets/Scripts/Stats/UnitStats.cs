using System.Collections;
using UnityEngine;

public class UnitStats : ObjStats
{
    [SerializeField] private int radius;
    [SerializeField] private float speed;
    [SerializeField] private int damage;
    [SerializeField] private int cost;
    [SerializeField] private int towerRadius;

    [SerializeField] private int maxUpgradeDamage;
    [SerializeField] private float maxUpgradeSpeed;
    [SerializeField] private int maxUpgradeHealth;

    [SerializeField] private bool purchased;

    public override void Start()
    {
        base.Start();
    }

    public int GetRadius()
    {
        return radius;
    }

    public float GetSpeed()
    {
        return PlayerPrefs.GetFloat(gameObject.name + "Speed", speed);
    }

    public int GetDamage()
    {
        return PlayerPrefs.GetInt(gameObject.name + "Damage", damage);
    }
    public override int GetStartHealth()
    {
        return PlayerPrefs.GetInt(gameObject.name + "Health", startHealth);
    }

    public int GetCost()
    {
        return cost;
    }

    public int GetTowerRadius()
    {
        return towerRadius;
    }

    public int GetMaxUpgradeDamage()
    {
        return maxUpgradeDamage;
    }

    public int GetMaxUpgradeHealth()
    {
        return maxUpgradeHealth;
    }

    public float GetMaxUpgradeSpeed()
    {
        return maxUpgradeSpeed;
    }

    public bool GetPurchased()
    {
        return Converter.IntToBool(PlayerPrefs.GetInt(gameObject.name + "Purchased", Converter.BoolToInt(purchased)));
    }

    public void SetPurchased()
    {
        PlayerPrefs.SetInt(gameObject.name + "Purchased", Converter.BoolToInt(true));
    }

    public void AddDamage(int _damage)
    {
        PlayerPrefs.SetInt(gameObject.name + "Damage", PlayerPrefs.GetInt(gameObject.name + "Damage", damage) + _damage);
    }

    public void AddSpeed(int _speed)
    {
        PlayerPrefs.SetFloat(gameObject.name + "Speed", PlayerPrefs.GetFloat(gameObject.name + "Speed", speed) + _speed);
    }

    public void AddStartHealth(int _health)
    {
        PlayerPrefs.SetInt(gameObject.name + "Health", PlayerPrefs.GetInt(gameObject.name + "Health", startHealth) + _health);
    }

    public IEnumerator AddTemporarilyDamage(int _damage, int duration)
    {
        AddDamage(_damage);
        yield return new WaitForSeconds(duration);
        AddDamage(-_damage);
    }


    public override void TakeDamage(int damage)
    {
        if (health <= 0 || health - damage <= 0)
        {
            health -= damage;
            healthBar.SetHealth(health);
            if (canAnimateDeath == true)
            {
                animator.SetTrigger("Death");
            }

            canAnimateDeath = false;
        }
        else
        {
            animator.SetTrigger("Hurt");
            health -= damage;
            healthBar.SetHealth(health);
        }

        GlobalEventManager.SendUnitDamaged();
    }

    public void DestroyUnit()
    {
        if (gameObject.tag == "SecondTeam")
        {
            PlayerSettings.instance.AddMoney(cost / 2);
        }

        Destroy(gameObject);

        GlobalEventManager.SendEnemyKilled();
    }
}



