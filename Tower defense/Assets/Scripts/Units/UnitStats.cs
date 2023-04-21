using System.Collections;
using UnityEngine;

public class UnitStats : MonoBehaviour
{
    [SerializeField] private int health;
    [SerializeField] private int radius;
    [SerializeField] private float speed;
    [SerializeField] private int damage;

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
        Destroy(gameObject);
    }
}
