using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject[] objsToHideShop;
    [SerializeField] private GameObject[] objsThoHideSelector;
    [SerializeField] private GameObject[] objsToHideTowerUpgade;

    [SerializeField] private GameObject shop;
    [SerializeField] private GameObject levelSelector;
    [SerializeField] private GameObject towerUpgrade;

    public void Play()
    {
        if (levelSelector.activeSelf == false)
        {
            levelSelector.SetActive(true);

            foreach (var obj in objsThoHideSelector)
            {
                obj.SetActive(false);
            }
        }
        else
        {
            levelSelector.SetActive(false);

            foreach (var obj in objsThoHideSelector)
            {
                obj.SetActive(true);
            }
        }

        GlobalEventManager.SendUIClcked();
    }

    public void Shop()
    {
        if (shop.activeSelf == false)
        {
            shop.SetActive(true);

            foreach (var obj in objsToHideShop)
            {
                obj.SetActive(false);
            }
        }
        else
        {
            shop.SetActive(false);

            foreach (var obj in objsToHideShop)
            {
                obj.SetActive(true);
            }
        }

        GlobalEventManager.SendUIClcked();
    }

    public void TowerUpgradeShop()
    {
        if (towerUpgrade.activeSelf == false)
        {
            towerUpgrade.SetActive(true);

            foreach (var obj in objsToHideTowerUpgade)
            {
                obj.SetActive(false);
            }
        }
        else
        {
            towerUpgrade.SetActive(false);

            foreach (var obj in objsToHideTowerUpgade)
            {
                obj.SetActive(true);
            }
        }

        GlobalEventManager.SendUIClcked();
    }
}
