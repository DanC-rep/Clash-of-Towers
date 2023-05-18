using UnityEngine;
using UnityEngine.UI;

public class ShopMenuEl : MonoBehaviour
{
    [SerializeField] private GameObject unit;
    [SerializeField] private Sprite unitIcon;

    [SerializeField] private Image placeToPutIcon;
    [SerializeField] private Text damageText, healthText, speedText;

    public static GameObject choosedUnit;

    public void ChooseUnit()
    {
        placeToPutIcon.enabled = true;
        placeToPutIcon.sprite = unitIcon;

        damageText.text = unit.GetComponent<UnitStats>().GetDamage().ToString();
        healthText.text = unit.GetComponent<UnitStats>().GetStartHealth().ToString();
        speedText.text = unit.GetComponent<UnitStats>().GetSpeed().ToString();

        choosedUnit = unit;
    }
}
