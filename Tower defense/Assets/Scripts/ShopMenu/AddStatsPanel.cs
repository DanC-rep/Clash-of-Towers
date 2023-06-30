using UnityEngine;
using UnityEngine.UI;

public class AddStatsPanel : MonoBehaviour
{
    [SerializeField] private int damageAdd, healthAdd, speedAdd;
    [SerializeField] private int damageCost, healthCost, speedCost;

    [SerializeField] private Text damageText, healthText, speedText;

    [SerializeField] private GameObject[] btns;

    private Color color;

    private void Start()
    {
        color = btns[0].GetComponent<Image>().color;
    }


    public void AddDamage()
    {
        if (ShopMenuEl.choosedUnit != null && PlayerSettings.instance.GetDiamonds() - damageCost >= 0 && 
            ShopMenuEl.choosedUnit.GetDamage() < ShopMenuEl.choosedUnit.GetMaxUpgradeDamage())
        {
            ShopMenuEl.choosedUnit.AddDamage(damageAdd);
            damageText.text = ShopMenuEl.choosedUnit.GetDamage().ToString();

            PlayerSettings.instance.DecreaseDiamonds(damageCost);

            GlobalEventManager.SendStatUpgraded();
        }
        else
        {
            StartCoroutine(UIColorChange.ChangeColorToRed(btns[0], color, new Color(1, 0.4566038f, 0.4566038f)));
        }

        GlobalEventManager.SendUIClcked();
    }

    public void AddSpeed()
    {
        if (ShopMenuEl.choosedUnit != null && PlayerSettings.instance.GetDiamonds() - speedCost >= 0 && 
            ShopMenuEl.choosedUnit.GetSpeed() < ShopMenuEl.choosedUnit.GetMaxUpgradeSpeed())
        {
            ShopMenuEl.choosedUnit.AddSpeed(speedAdd);
            speedText.text = ShopMenuEl.choosedUnit.GetSpeed().ToString();

            PlayerSettings.instance.DecreaseDiamonds(speedCost);

            GlobalEventManager.SendStatUpgraded();
        }
        else
        {
            StartCoroutine(UIColorChange.ChangeColorToRed(btns[2], color, new Color(1, 0.4566038f, 0.4566038f)));
        }

        GlobalEventManager.SendUIClcked();
    }

    public void AddHealth()
    {
        if (ShopMenuEl.choosedUnit != null && PlayerSettings.instance.GetDiamonds() - healthCost >= 0 && 
            ShopMenuEl.choosedUnit.GetStartHealth() < ShopMenuEl.choosedUnit.GetMaxUpgradeHealth())
        {
            ShopMenuEl.choosedUnit.AddStartHealth(healthAdd);
            healthText.text = ShopMenuEl.choosedUnit.GetStartHealth().ToString();

            PlayerSettings.instance.DecreaseDiamonds(healthCost);

            GlobalEventManager.SendStatUpgraded();
        }
        else
        {
            StartCoroutine(UIColorChange.ChangeColorToRed(btns[1], color, new Color(1, 0.4566038f, 0.4566038f)));
        }

        GlobalEventManager.SendUIClcked();
    }

    public int GetDamageCost()
    {
        return damageCost;
    }

    public int GetHealthCost()
    {
        return healthCost;
    }

    public int GetSpeedCost()
    {
        return speedCost;
    }
}
