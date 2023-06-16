using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ShopEl : MonoBehaviour
{
    [SerializeField] private GameObject unit;
    [SerializeField] private PlayerSettings playerSettings;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private Transform parent;
    [SerializeField] private Button button;
    [SerializeField] private int buyCooldown;

    private Color color;

    private void Start()
    {
        if (!unit.GetComponent<UnitStats>().purchased)
        {
            gameObject.SetActive(false);
        }

        color = gameObject.GetComponent<Image>().color;
    }

    public void PurchaseUnit()
    {
        int unitCost = unit.GetComponent<UnitStats>().GetCost();

        if (playerSettings.GetMoney() - unitCost >= 0)
        {
            playerSettings.DecreaseMoney(unitCost);
            GameObject newUnit = Instantiate(unit, spawnPoint.position, spawnPoint.rotation, parent);
            newUnit.transform.position = new Vector3(spawnPoint.position.x, spawnPoint.position.y, 1);

            GlobalEventManager.SendPurchaseUnit();

            StartCoroutine(BuyCooldown());
        }
        else
        {
            StartCoroutine(UIColorChange.ChangeColorToRed(gameObject, color, new Color(1, 0.6075472f, 0.6075472f)));
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
