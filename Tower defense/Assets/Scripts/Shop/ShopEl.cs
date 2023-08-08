using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ShopEl : MonoBehaviour
{
    [SerializeField] private UnitStats unit;
    [SerializeField] private PlayerSettings playerSettings;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private Transform parent;
    [SerializeField] private Button button;
    [SerializeField] private int buyCooldown;
    [SerializeField] private Text costText;

    private Color color;

    private void Start()
    {
        if (!unit.GetPurchased())
        {
            gameObject.SetActive(false);
        }

        color = button.gameObject.GetComponent<Image>().color;

        costText.text = unit.GetCost().ToString();
    }

    public void PurchaseUnit()
    {
        int unitCost = unit.GetCost();

        if (playerSettings.GetMoney() - unitCost >= 0)
        {
            playerSettings.DecreaseMoney(unitCost);
            GameObject newUnit = Instantiate(unit.gameObject, spawnPoint.position, spawnPoint.rotation, parent);
            newUnit.name = newUnit.name.Substring(0, newUnit.name.IndexOf('('));
            newUnit.transform.position = new Vector3(spawnPoint.position.x, spawnPoint.position.y, 1);

            GlobalEventManager.SendPurchaseUnit();

            StartCoroutine(BuyCooldown());
        }
        else
        {
            StartCoroutine(UIColorChange.ChangeColorToRed(button.gameObject, color, new Color(1, 0.6075472f, 0.6075472f)));
        }

        GlobalEventManager.SendUIClcked();
    }

    IEnumerator BuyCooldown()
    {
        button.interactable = false;
        yield return new WaitForSeconds(buyCooldown);
        button.interactable = true;
    }
}
