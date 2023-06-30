using UnityEngine;
using UnityEngine.UI;

public class ShopMenuEl : MonoBehaviour
{
    [SerializeField] private UnitStats unit;
    [SerializeField] private Sprite unitIcon;

    [SerializeField] private Image placeToPutIcon;
    [SerializeField] private Text damageText, healthText, speedText;

    [SerializeField] private Text unitCost;
    [SerializeField] private Image diamondIcon;

    public static UnitStats choosedUnit;

    private Color color;

    private void Start()
    {
        if (!unit.GetPurchased())
        {
            unitCost.text = unit.GetDiamondsCost().ToString();
        }
        else
        {
            unitCost.enabled = false;
            diamondIcon.enabled = false;
        }

        color = gameObject.GetComponent<Image>().color;
    }

    public void ChooseUnit()
    {
        if (unit.GetPurchased() == true)
        {
            OpenUnit();
            GlobalEventManager.SendChooseUnit();
        }
        else
        {
            if (PlayerSettings.instance.GetDiamonds() - unit.GetDiamondsCost() >= 0)
            {
                unit.SetPurchased();
                PlayerSettings.instance.DecreaseDiamonds(unit.GetDiamondsCost());
                unitCost.enabled = false;
                diamondIcon.enabled = false;

                OpenUnit();

                GlobalEventManager.SendUnitPurchaseDiamonds();
                GlobalEventManager.SendChooseUnit();
            }
            else
            {
                StartCoroutine(UIColorChange.ChangeColorToRed(gameObject, color, new Color(1, 0.6075472f, 0.6075472f)));
            }
        }

        GlobalEventManager.SendUIClcked();
    }

    private void OpenUnit()
    {
        placeToPutIcon.enabled = true;
        placeToPutIcon.sprite = unitIcon;

        damageText.text = unit.GetDamage().ToString();
        healthText.text = unit.GetStartHealth().ToString();
        speedText.text = unit.GetSpeed().ToString();

        choosedUnit = unit;
    }
}
