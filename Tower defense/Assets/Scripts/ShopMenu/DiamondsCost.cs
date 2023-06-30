using UnityEngine;
using UnityEngine.UI;

public class DiamondsCost : MonoBehaviour
{
    [SerializeField] private Text damageCostText, healthCostText, speedCostText;
    [SerializeField] private AddStatsPanel addStatsPanel;

    private void Start()
    {
        GlobalEventManager.OnChooseUnit.AddListener(ShowDiamondsCost);
    }

    private void ShowDiamondsCost()
    {
        if (ShopMenuEl.choosedUnit != null)
        {
            damageCostText.text = addStatsPanel.GetDamageCost().ToString();
            healthCostText.text = addStatsPanel.GetHealthCost().ToString();
            speedCostText.text = addStatsPanel.GetSpeedCost().ToString();
        }
    }
}
