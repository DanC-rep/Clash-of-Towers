using UnityEngine;
using UnityEngine.UI;

public class Diamonds : MonoBehaviour
{
    private Text diamondsText;
    

    private void Start()
    {
        diamondsText = GetComponent<Text>();
        diamondsText.text = PlayerSettings.instance.GetDiamonds().ToString();
    }

    private void Update()
    {
        diamondsText.text = PlayerSettings.instance.GetDiamonds().ToString();
    }
}
