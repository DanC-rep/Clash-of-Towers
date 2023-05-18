using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject[] objsToHideShop;
    [SerializeField] private GameObject[] objsThoHideSelector;

    [SerializeField] private GameObject shop;
    [SerializeField] private GameObject levelSelector;

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
    }

    public void Settings()
    {
        Debug.Log("Settings");
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
    }
}
