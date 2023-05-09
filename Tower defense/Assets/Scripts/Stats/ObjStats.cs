using UnityEngine;

public class ObjStats : MonoBehaviour
{
    [SerializeField] private protected int startHealth;
    [SerializeField] private protected HealthBar healthBar;

    private protected int health;

    private void Start()
    {
        healthBar.SetMaxHealth(startHealth);

        health = startHealth;
    }

    public int GetHealth()
    {

        return health;
    }

    public virtual void TakeDamage(int damage)
    {
        
    }
}
