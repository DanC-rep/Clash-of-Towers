using System.Collections;
using UnityEngine;

public class UnitStats : ObjStats
{
    [SerializeField] private int radius;
    [SerializeField] private float speed;
    [SerializeField] private int damage;
    [SerializeField] private int cost;
    [SerializeField] private int towerRadius;

    public bool purchased;

    public int GetRadius()
    {
        return radius;
    }

    public float GetSpeed()
    {
        return speed;
    }

    public int GetDamage()
    {
        return damage;
    }

    public int GetCost()
    {
        return cost;
    }

    public int GetTowerRadius()
    {
        return towerRadius;
    }

    public void AddDamage(int _damage)
    {
        damage += _damage;
    }

    public void AddSpeed(int _speed)
    {
        speed += _speed;
    }

    public void AddStartHealth(int _health)
    {
        startHealth += _health;
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
                gameObject.GetComponent<Animator>().SetTrigger("Death");
            }

            canAnimateDeath = false;
        }
        else
        {
            gameObject.GetComponent<Animator>().SetTrigger("Hurt");
            health -= damage;
            healthBar.SetHealth(health);
        }

        GlobalEventManager.SendUnitDamaged();
    }

    public void DestroyUnit()
    {
        if (gameObject.tag == "SecondTeam")
        {
            PlayerSettings.instance.AddMoney(cost);
        }

        Destroy(gameObject);

        GlobalEventManager.SendEnemyKilled();
    }
}
