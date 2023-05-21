using UnityEngine;

public class TowerStats : ObjStats
{
    [SerializeField] private GameObject endGamePanel;
    [SerializeField] private int diamonds;

    public override void TakeDamage(int damage)
    {
        if (health <= 0 || health - damage / 2 <= 0)
        {
            health -= damage / 2;
            healthBar.SetHealth(health);

            gameObject.GetComponent<Animator>().SetTrigger("0%");
        }
        else
        {
            health -= damage / 2;
            healthBar.SetHealth(health);

            if (health <= startHealth * 75 / 100 && health > startHealth * 50 / 100)
            {
                gameObject.GetComponent<Animator>().SetTrigger("75%");
            }
            else if (health <= startHealth * 50 / 100 && health > startHealth * 25 / 100)
            {
                gameObject.GetComponent<Animator>().SetTrigger("50%");
            }
            else if (health <= startHealth * 25 / 100 && health > 0)
            {
                gameObject.GetComponent<Animator>().SetTrigger("25%");
            }
        }
    }

    private void DestroyTower()
    {
        Destroy(gameObject);

        endGamePanel.SetActive(true);

        PlayerSettings.instance.AddDiamonds(diamonds);

        GlobalEventManager.SendTowerDestroy(gameObject.tag);
    }

    public int GetAddedDiamonds()
    {
        return diamonds;
    }
}
