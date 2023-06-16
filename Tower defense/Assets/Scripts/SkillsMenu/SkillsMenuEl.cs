using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class SkillsMenuEl : MonoBehaviour
{
    [SerializeField] int diamondsCost;
    [SerializeField] int valueAdd;
    [SerializeField] int tempDuration;

    [SerializeField] Text diamondsCostText;

    [SerializeField] TempSkillsCaller tempCaller;

    private Color color;

    private void Start()
    {
        diamondsCostText.text = diamondsCost.ToString();

        color = gameObject.GetComponent<Image>().color;
    }

    public void AddTowerHealth()
    {
        GameObject tower = GameObject.FindGameObjectWithTag("RedTower");
        bool healthCond = tower.GetComponent<TowerStats>().GetHealth() < tower.GetComponent<TowerStats>().GetStartHealth();

        if (PlayerSettings.instance.GetDiamonds() - diamondsCost >= 0 && tower != null && healthCond)
        {
            PlayerSettings.instance.DecreaseDiamonds(diamondsCost);

            tower.GetComponent<TowerStats>().AddHealth(valueAdd);

            GlobalEventManager.SendSkillPurchase();
        }
        else
        {
            StartCoroutine(UIColorChange.ChangeColorToRed(gameObject, color, new Color(1, 0.4566038f, 0.4566038f)));
        }

        GlobalEventManager.SendUIClcked();
    }

    public void AddHealth()
    {
        GameObject[] units = GameObject.FindGameObjectsWithTag("FirstTeam");

        if (PlayerSettings.instance.GetDiamonds() - diamondsCost >= 0 && units.Length > 0)
        {
            PlayerSettings.instance.DecreaseDiamonds(diamondsCost);

            foreach (var unit in units)
            {
                unit.GetComponent<UnitStats>().AddHealth(valueAdd);
            }

            GlobalEventManager.SendSkillPurchase();
        }
        else
        {
            StartCoroutine(UIColorChange.ChangeColorToRed(gameObject, color, new Color(1, 0.4566038f, 0.4566038f)));
        }

        GlobalEventManager.SendUIClcked();
    }

    public void AddDamage()
    {
        GameObject[] units = GameObject.FindGameObjectsWithTag("FirstTeam");

        if (PlayerSettings.instance.GetDiamonds() - diamondsCost >= 0 && units.Length > 0)
        {
            PlayerSettings.instance.DecreaseDiamonds(diamondsCost);

            foreach (var unit in units)
            {
                tempCaller.CallAddDamage(unit.GetComponent<UnitStats>(), valueAdd, tempDuration);
            }

            GlobalEventManager.SendSkillPurchase();
        }
        else
        {
            StartCoroutine(UIColorChange.ChangeColorToRed(gameObject, color, new Color(1, 0.4566038f, 0.4566038f)));
        }

        GlobalEventManager.SendUIClcked();
    }

    public void AddMoney()
    {
        if (PlayerSettings.instance.GetDiamonds() - diamondsCost >= 0)
        {
            PlayerSettings.instance.DecreaseDiamonds(diamondsCost);

            tempCaller.CallAddMoney(valueAdd, tempDuration);

            GlobalEventManager.SendSkillPurchase();
        }
        else
        {
            StartCoroutine(UIColorChange.ChangeColorToRed(gameObject, color, new Color(1, 0.4566038f, 0.4566038f)));
        }

        GlobalEventManager.SendUIClcked();
    }
}

