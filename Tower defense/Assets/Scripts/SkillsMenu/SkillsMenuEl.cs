using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class SkillsMenuEl : MonoBehaviour
{
    [SerializeField] private int diamondsCost;
    [SerializeField] private int tempDuration;
    [SerializeField] private int buyCooldown;

    [SerializeField] Text diamondsCostText;

    [SerializeField] TempSkillsCaller tempCaller;


    private Color color;
    private int valueAdd;

    private TowerStats tower;

    private void Start()
    {
        diamondsCostText.text = diamondsCost.ToString();

        color = gameObject.GetComponent<Image>().color;

        tower = GameObject.FindGameObjectWithTag("RedTower").GetComponent<TowerStats>();
    }

    public void AddTowerHealth()
    {
        bool healthCond = tower.GetHealth() < tower.GetStartHealth();
        valueAdd = tower.GetStartHealth() * 20 / 100;

        if (PlayerSettings.instance.GetDiamonds() - diamondsCost >= 0 && tower != null && healthCond)
        {
            PlayerSettings.instance.DecreaseDiamonds(diamondsCost);

            tower.AddHealth(valueAdd);

            GlobalEventManager.SendSkillPurchase("AddTowerHealth");

            tempCaller.CallBuyCooldown(this, gameObject.GetComponent<Button>());
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
                valueAdd = unit.GetComponent<UnitStats>().GetStartHealth() * 30 / 100;
                unit.GetComponent<UnitStats>().AddHealth(valueAdd);
            }

            GlobalEventManager.SendSkillPurchase("AddHealth");

            tempCaller.CallBuyCooldown(this, gameObject.GetComponent<Button>());
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
                valueAdd = unit.GetComponent<UnitStats>().GetDamage() * 50 / 100;
                tempCaller.CallAddDamage(unit.GetComponent<UnitStats>(), valueAdd, tempDuration);
            }

            GlobalEventManager.SendSkillPurchase("AddDamage");

            tempCaller.CallBuyCooldown(this, gameObject.GetComponent<Button>());
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

            valueAdd = Convert.ToInt32(PlayerSettings.instance.GetMoneyPerTime());

            tempCaller.CallAddMoney(valueAdd, tempDuration);

            GlobalEventManager.SendSkillPurchase("AddMoney");

            tempCaller.CallBuyCooldown(this, gameObject.GetComponent<Button>());
        }
        else
        {
            StartCoroutine(UIColorChange.ChangeColorToRed(gameObject, color, new Color(1, 0.4566038f, 0.4566038f)));
        }

        GlobalEventManager.SendUIClcked();
    }

    public IEnumerator BuyCooldown(Button button)
    {
        button.interactable = false;
        yield return new WaitForSeconds(buyCooldown);
        button.interactable = true;
    }
}

