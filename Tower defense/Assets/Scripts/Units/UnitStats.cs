using System.Collections;
using UnityEngine;

public class UnitStats : MonoBehaviour
{
    [SerializeField] private int health;
    [SerializeField] private int radius;
    [SerializeField] private float speed;
    [SerializeField] private int damage;
    [SerializeField] private int cost;

    [SerializeField] private HealthBar healthBar;

    private void Start()
    {
        healthBar.SetMaxHealth(health);
    }

    public int GetHealth()
    {
        return health;
    }

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

    public void TakeDamage(int damage)
    {
        if (health <= 0 || health - damage <= 0)
        {
            health -= damage;
            healthBar.SetHealth(health);
            gameObject.GetComponent<Animator>().SetTrigger("Death");
        }
        else
        {
            gameObject.GetComponent<Animator>().SetTrigger("Hurt");
            health -= damage;
            healthBar.SetHealth(health);
        }
    }

    private void DestroyUnit()
    {
        if (gameObject.tag == "SecondTeam")
        {
            PlayerSettings.instance.AddMoney(cost);
        }

        Destroy(gameObject);
    }
}
