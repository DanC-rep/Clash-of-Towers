using UnityEngine;
using UnityEngine.UI;

public class Money : MonoBehaviour
{
    private Text moneyText;

    private void Start()
    {
        moneyText = GetComponent<Text>();
        moneyText.text = PlayerSettings.instance.GetMoney().ToString();

        GlobalEventManager.OnEnemyKilled.AddListener(SetTextMoney);
        GlobalEventManager.OnPurchaseUnit.AddListener(SetTextMoney);
        GlobalEventManager.OnMoneyAddedPerTime.AddListener(SetTextMoney);
    }

    private void SetTextMoney()
    {
        moneyText.text = PlayerSettings.instance.GetMoney().ToString();
    }

}
