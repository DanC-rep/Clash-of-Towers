using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField] private Button[] buttons;

    [SerializeField] private float timeStart;
    
    private Text timerText;
    private bool timeRunnning = true; 


    private void Start()
    {
        foreach (var button in buttons)
        {
            button.interactable = false;
        }
        timerText = GetComponent<Text>();
        timerText.text = timeStart.ToString();
    }

    private void Update()
    {
        if (timeRunnning)
        {
            timeStart -= Time.deltaTime;
            timerText.text = Mathf.Round(timeStart).ToString();
            if (timeStart <= 0)
            {
                timeRunnning = false;
            }
        }

        if (!timeRunnning)
        {
            foreach (var button in buttons)
            {
                button.interactable = true;
            }

            timerText.enabled = false;
        }
    }
}
