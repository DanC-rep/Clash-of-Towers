using UnityEngine;
using UnityEngine.UI;

public class SkillsMenu : MonoBehaviour
{
    [SerializeField] private Image placeToPutMenuImg;
    [SerializeField] private Sprite openMenuMinusImg;
    [SerializeField] private Sprite openMenuPlusImg;
    [SerializeField] private GameObject skillsMenu;

    private void Start()
    {
        Pause.OnMenuClosed.AddListener(ChangeButtonIcon);
    }

    public void OpenMenu()
    {
        if (skillsMenu.activeSelf == false)
        {
            skillsMenu.SetActive(true);
            placeToPutMenuImg.sprite = openMenuMinusImg;
        }
        else if (skillsMenu.activeSelf == true)
        {
            skillsMenu.SetActive(false);
            placeToPutMenuImg.sprite = openMenuPlusImg;
        }

        GlobalEventManager.SendUIClcked();
    }

    private void ChangeButtonIcon()
    {
        placeToPutMenuImg.sprite = openMenuPlusImg;
    }
}
