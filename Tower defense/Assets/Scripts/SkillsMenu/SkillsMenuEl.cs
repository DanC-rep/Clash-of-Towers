using UnityEngine;
using UnityEngine.UI;

public class SkillsMenuEl : MonoBehaviour
{
    [SerializeField] int diamondsCost;
    [SerializeField] int valueAdd;
    [SerializeField] private int tempDamageDuration;

    [SerializeField] Text diamondsCostText;

    private void Start()
    {
        diamondsCostText.text = diamondsCost.ToString();
    }

    public void AddTowerHealth()
    {
        if (PlayerSettings.instance.GetDiamonds() - diamondsCost >= 0)
        {
            PlayerSettings.instance.DecreaseDiamonds(diamondsCost);

            GameObject tower = GameObject.FindGameObjectWithTag("RedTower");
            tower.GetComponent<TowerStats>().AddHealth(valueAdd);

            GlobalEventManager.SendSkillPurchase();
        }
    }

    public void AddHealth()
    {

        if (PlayerSettings.instance.GetDiamonds() - diamondsCost >= 0)
        {
            PlayerSettings.instance.DecreaseDiamonds(diamondsCost);

            GameObject[] units = GameObject.FindGameObjectsWithTag("FirstTeam");

            foreach (var unit in units)
            {
                unit.GetComponent<UnitStats>().AddHealth(valueAdd);
            }

            GlobalEventManager.SendSkillPurchase();
        }
    }

    public void AddDamage()
    {

        if (PlayerSettings.instance.GetDiamonds() - diamondsCost >= 0)
        {
            PlayerSettings.instance.DecreaseDiamonds(diamondsCost);

            GameObject[] units = GameObject.FindGameObjectsWithTag("FirstTeam");

            foreach (var unit in units)
            {
                StartCoroutine(unit.GetComponent<UnitStats>().AddTemporarilyDamage(valueAdd, tempDamageDuration));
            }

            GlobalEventManager.SendSkillPurchase();
        }
    }
}

