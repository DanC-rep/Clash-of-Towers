using UnityEngine;

public class ObjStats : MonoBehaviour
{
    [SerializeField] private protected int startHealth;
    [SerializeField] private protected HealthBar healthBar;
    [SerializeField] private int diamondsCost;

    private protected int health;

    private protected bool canAnimateDeath = true;

    private protected Animator animator;

    public virtual void Start()
    {
        healthBar.SetMaxHealth(startHealth);

        health = startHealth;

        animator = gameObject.GetComponent<Animator>();
    }

    public int GetHealth()
    {

        return health;
    }

    public virtual int GetStartHealth()
    {
        return startHealth;
    }

    public int GetDiamondsCost()
    {
        return diamondsCost;
    }

    public void AddHealth(int _health)
    {
        if (health + _health <= startHealth)
        {
            health += _health;
        }
        else
        {
            health = startHealth;
        }

        healthBar.SetHealth(health);
    }


    public virtual void TakeDamage(int damage)
    {
        
    }
}
