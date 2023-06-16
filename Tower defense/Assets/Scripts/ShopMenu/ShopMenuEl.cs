using UnityEngine;
using UnityEngine.UI;

public class ShopMenuEl : MonoBehaviour
{
    [SerializeField] private GameObject unit;
    [SerializeField] private Sprite unitIcon;

    [SerializeField] private Image placeToPutIcon;
    [SerializeField] private Text damageText, healthText, speedText;

    [SerializeField] private Text unitCost;
    [SerializeField] private Image diamondIcon;

    public static GameObject choosedUnit;

    private Color color;

    private void Start()
    {
        if (!unit.GetComponent<UnitStats>().purchased)
        {
            unitCost.text = unit.GetComponent<UnitStats>().GetDiamondsCost().ToString();
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
        if (unit.GetComponent<UnitStats>().purchased == true)
        {
            OpenUnit();
        }
        else
        {
            if (PlayerSettings.instance.GetDiamonds() - unit.GetComponent<UnitStats>().GetDiamondsCost() >= 0)
            {
                unit.GetComponent<UnitStats>().purchased = true;
                PlayerSettings.instance.DecreaseDiamonds(unit.GetComponent<UnitStats>().GetDiamondsCost());
                unitCost.enabled = false;
                diamondIcon.enabled = false;

                OpenUnit();

                GlobalEventManager.SendUnitPurchaseDiamonds();
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

        damageText.text = unit.GetComponent<UnitStats>().GetDamage().ToString();
        healthText.text = unit.GetComponent<UnitStats>().GetStartHealth().ToString();
        speedText.text = unit.GetComponent<UnitStats>().GetSpeed().ToString();

        choosedUnit = unit;
    }
}
