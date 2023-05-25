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
    [SerializeField] private Button upgradeBtn;

    private int currentTowerLevel = 0;

    private void Start()
    {
        currentTowerLevel = PlayerPrefs.GetInt("towerLevel", 0);

        if (currentTowerLevel + 1 >= towers.Length)
        {
            upgradeBtn.interactable = false;
        }

        placeToPutImg.enabled = true;
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

    }

    public void UpgradeTower()
    {
        if (currentTowerLevel + 1 < towers.Length && PlayerSettings.instance.GetDiamonds() - towers[currentTowerLevel + 1].GetComponent<TowerStats>().GetDiamondsCost() >= 0)
        {
            PlayerPrefs.SetInt("towerLevel", currentTowerLevel + 1);
            currentTowerLevel = PlayerPrefs.GetInt("towerLevel", 0);

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
        else
        {
            upgradeBtn.interactable = false;
        }
    }
}
