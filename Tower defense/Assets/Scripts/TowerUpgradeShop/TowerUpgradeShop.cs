using UnityEngine;
using UnityEngine.UI;

public class TowerUpgradeShop : MonoBehaviour
{
    [SerializeField] private TowerStats[] towers;
    [SerializeField] private Sprite[] towerIcons;
    [SerializeField] private Text healthText;
    [SerializeField] private Text moneyPerSec;
    [SerializeField] private Text costText;
    [SerializeField] private Image placeToPutImg;
    [SerializeField] private Image diamondIcon;
    [SerializeField] private Button upgradeBtn;

    private int currentTowerLevel = 0;
    private Color color;

    private void Start()
    {
        currentTowerLevel = PlayerPrefs.GetInt("towerLevel", 0);

        if (currentTowerLevel + 1 >= towers.Length)
        {
            upgradeBtn.interactable = false;
        }

        placeToPutImg.enabled = true;
        placeToPutImg.sprite = towerIcons[currentTowerLevel];
        healthText.text = "Здоровье: " + towers[currentTowerLevel].GetStartHealth().ToString();
        moneyPerSec.text = "Монеты/с: " + towers[currentTowerLevel].GetMoneyPerTime().ToString();

        if (currentTowerLevel + 1 < towers.Length)
        {
            costText.text = towers[currentTowerLevel + 1].GetDiamondsCost().ToString();
        }
        else
        {
            costText.text = "Макс.";
            diamondIcon.enabled = false;
        }

        color = upgradeBtn.gameObject.GetComponent<Image>().color;
    }

    public void UpgradeTower()
    {
        if (currentTowerLevel + 1 < towers.Length && PlayerSettings.instance.GetDiamonds() - towers[currentTowerLevel + 1].GetDiamondsCost() >= 0)
        {
            PlayerPrefs.SetInt("towerLevel", currentTowerLevel + 1);
            currentTowerLevel = PlayerPrefs.GetInt("towerLevel", 0);

            PlayerSettings.instance.DecreaseDiamonds(towers[currentTowerLevel].GetDiamondsCost());

            placeToPutImg.sprite = towerIcons[currentTowerLevel];
            healthText.text = "Health: " + towers[currentTowerLevel].GetStartHealth().ToString();
            moneyPerSec.text = "Монеты/с: " + towers[currentTowerLevel].GetMoneyPerTime().ToString();

            if (currentTowerLevel + 1 < towers.Length)
            {
                costText.text = towers[currentTowerLevel + 1].GetDiamondsCost().ToString();
            }
            else
            {
                costText.text = "Макс.";
                diamondIcon.enabled = false;
            }

            GlobalEventManager.SendUnitPurchaseDiamonds();
        }
        else
        {
            StartCoroutine(UIColorChange.ChangeColorToRed(upgradeBtn.gameObject, color, new Color(1, 0.56f, 0.56f)));
        }

        GlobalEventManager.SendUIClcked();
    }
}
