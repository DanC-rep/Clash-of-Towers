using UnityEngine;
using UnityEngine.UI;

public class Money : MonoBehaviour
{
    private Text moneyText;

    private void Start()
    {
        moneyText = GetComponent<Text>();
        moneyText.text = PlayerSettings.instance.GetMoney().ToString();
    }

    private void Update()
    {
        moneyText.text = PlayerSettings.instance.GetMoney().ToString();
    }

}
