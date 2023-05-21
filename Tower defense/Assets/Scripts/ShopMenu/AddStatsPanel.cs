using UnityEngine;
using UnityEngine.UI;

public class AddStatsPanel : MonoBehaviour
{
    [SerializeField] private int damageAdd, healthAdd, speedAdd;
    [SerializeField] private int damageCost, healthCost, speedCost;

    [SerializeField] private Text damageText, healthText, speedText;
    

    public void AddDamage()
    {
        if (ShopMenuEl.choosedUnit != null && PlayerSettings.instance.GetDiamonds() - damageCost >= 0)
        {
            ShopMenuEl.choosedUnit.GetComponent<UnitStats>().AddDamage(damageAdd);
            damageText.text = ShopMenuEl.choosedUnit.GetComponent<UnitStats>().GetDamage().ToString();

            PlayerSettings.instance.DecreaseDiamonds(damageCost);

            GlobalEventManager.SendStatUpgraded();
        } 
    }

    public void AddSpeed()
    {
        if (ShopMenuEl.choosedUnit != null && PlayerSettings.instance.GetDiamonds() - speedCost >= 0)
        {
            ShopMenuEl.choosedUnit.GetComponent<UnitStats>().AddSpeed(speedAdd);
            speedText.text = ShopMenuEl.choosedUnit.GetComponent<UnitStats>().GetSpeed().ToString();

            PlayerSettings.instance.DecreaseDiamonds(speedCost);

            GlobalEventManager.SendStatUpgraded();
        }
    }

    public void AddHealth()
    {
        if (ShopMenuEl.choosedUnit != null && PlayerSettings.instance.GetDiamonds() - healthCost >= 0)
        {
            ShopMenuEl.choosedUnit.GetComponent<UnitStats>().AddStartHealth(healthAdd);
            healthText.text = ShopMenuEl.choosedUnit.GetComponent<UnitStats>().GetStartHealth().ToString();

            PlayerSettings.instance.DecreaseDiamonds(healthCost);

            GlobalEventManager.SendStatUpgraded();
        }
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
