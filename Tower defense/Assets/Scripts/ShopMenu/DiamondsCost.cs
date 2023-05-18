using UnityEngine;
using UnityEngine.UI;

public class DiamondsCost : MonoBehaviour
{
    [SerializeField] private Text damageCostText, healthCostText, speedCostText;
    [SerializeField] private AddStatsPanel addStatsPanel;

    private void Update()
    {
        if (ShopMenuEl.choosedUnit != null)
        {
            damageCostText.text = addStatsPanel.GetDamageCost().ToString();
            healthCostText.text = addStatsPanel.GetHealthCost().ToString();
            speedCostText.text = addStatsPanel.GetSpeedCost().ToString();
        }
    }
}
