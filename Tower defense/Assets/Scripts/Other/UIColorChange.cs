using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIColorChange : MonoBehaviour
{
    public static IEnumerator ChangeColorToRed(GameObject gameObj, Color startColor, Color changedColor)
    {
        gameObj.GetComponent<Image>().color = changedColor;
        yield return new WaitForSeconds(0.2f);
        gameObj.GetComponent<Image>().color = startColor;
    }
}
