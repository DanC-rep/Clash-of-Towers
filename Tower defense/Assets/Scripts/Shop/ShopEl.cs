using UnityEngine;

public class ShopEl : MonoBehaviour
{
    [SerializeField] private GameObject unit;
    [SerializeField] private PlayerSettings playerSettings;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private Transform parent;

    private void Start()
    {
        if (!unit.GetComponent<UnitStats>().purchased)
        {
            gameObject.SetActive(false);
        }
    }

    public void PurchaseUnit()
    {
        int unitCost = unit.GetComponent<UnitStats>().GetCost();

        if (playerSettings.GetMoney() - unitCost >= 0)
        {
            playerSettings.DecreaseMoney(unitCost);
            GameObject newUnit = Instantiate(unit, spawnPoint.position, spawnPoint.rotation, parent);
            newUnit.transform.position = new Vector3(spawnPoint.position.x, spawnPoint.position.y, 1);

        }
        else
        {
            Debug.Log("Not enough money");
        }
    }
}
