using UnityEngine;
using UnityEngine.UI;

public class Money : MonoBehaviour
{
    private Text moneyText;

    [SerializeField] private Text moneyPerSec;

    private void Start()
    {
        moneyText = GetComponent<Text>();
        moneyText.text = PlayerSettings.instance.GetMoney().ToString();

        moneyPerSec.text= string.Format("{0:0.00}", PlayerSettings.instance.GetMoneyPerSec()) + "/sec";

        GlobalEventManager.OnEnemyKilled.AddListener(SetTextMoney);
        GlobalEventManager.OnPurchaseUnit.AddListener(SetTextMoney);
        GlobalEventManager.OnMoneyAddedPerTime.AddListener(SetTextMoney);
    }

    private void SetTextMoney()
    {
        moneyText.text = PlayerSettings.instance.GetMoney().ToString();

        moneyPerSec.text = string.Format("{0:0.00}", PlayerSettings.instance.GetMoneyPerSec()) + "/sec";
    }

}
