using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField] private Button[] buttons;

    [SerializeField] private float timeStart;
    
    private Text timerText;


    private void Start()
    {
        foreach (var button in buttons)
        {
            button.interactable = false;
        }
        timerText = GetComponent<Text>();
        timerText.text = timeStart.ToString();

        StartCoroutine(TimerRun());
    }

    IEnumerator TimerRun()
    {
        while (timeStart > 0)
        {
            timeStart -= Time.deltaTime;
            timerText.text = Mathf.Round(timeStart).ToString();
            yield return null;
        }

        foreach (var button in buttons)
        {
            button.interactable = true;
        }

        timerText.enabled = false;
    }
}
