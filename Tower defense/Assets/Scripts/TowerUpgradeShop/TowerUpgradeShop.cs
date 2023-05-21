using UnityEngine;
using UnityEngine.UI;

public class TowerUpgradeShop : MonoBehaviour
{
    [SerializeField] private GameObject[] towers;
    [SerializeField] private Sprite[] towerIcons;
    [SerializeField] private Text healthText;
    [SerializeField] private Text costText;
    [SerializeField] private Image placeToPutImg;
    [SerializeField] private Image diamondIcon;

    private int currentTowerLevel = 0;

    private void Start()
    {
        placeToPutImg.enabled = true;
        placeToPutImg.sprite = towerIcons[currentTowerLevel];

        costText.text = towers[currentTowerLevel + 1].GetComponent<TowerStats>().GetDiamondsCost().ToString();

        healthText.text = "Health: " + towers[currentTowerLevel].GetComponent<TowerStats>().GetStartHealth().ToString();
    }

    public void UpgradeTower()
    {
        if (PlayerSettings.instance.GetDiamonds() - towers[currentTowerLevel + 1].GetComponent<TowerStats>().GetDiamondsCost() >= 0 && currentTowerLevel + 1 < towers.Length)
        {
            currentTowerLevel += 1;
            PlayerSettings.instance.DecreaseDiamonds(towers[currentTowerLevel].GetComponent<TowerStats>().GetDiamondsCost());

            placeToPutImg.sprite = towerIcons[currentTowerLevel];
            healthText.text = "Health: " + towers[currentTowerLevel].GetComponent<TowerStats>().GetStartHealth().ToString();

            if (currentTowerLevel + 1 < towers.Length)
            {
                costText.text = towers[currentTowerLevel + 1].GetComponent<TowerStats>().GetDiamondsCost().ToString();
            }
            else
            {
                costText.text = "Max Level";
                diamondIcon.enabled = false;
            }

            GlobalEventManager.SendUnitPurchaseDiamonds();
        }
    }
}
