using UnityEngine;
using UnityEngine.UI;

public class Diamonds : MonoBehaviour
{
    private Text diamondsText;
    

    private void Start()
    {
        diamondsText = GetComponent<Text>();
        diamondsText.text = PlayerSettings.instance.GetDiamonds().ToString();

        GlobalEventManager.OnTowerDestroy.AddListener(SetDiamonds);
        GlobalEventManager.OnPurchaseUnitDiamonds.AddListener(SetDiamonds);
        GlobalEventManager.OnStatUpgraded.AddListener(SetDiamonds);
    }

    private void SetDiamonds()
    {
        diamondsText.text = PlayerSettings.instance.GetDiamonds().ToString();
    }

    private void SetDiamonds(string towerName)
    {
        diamondsText.text = PlayerSettings.instance.GetDiamonds().ToString();
    }
}
