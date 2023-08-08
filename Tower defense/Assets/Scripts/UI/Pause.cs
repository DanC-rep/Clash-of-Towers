using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Pause : MonoBehaviour
{
    [SerializeField] private GameObject pausePanel;
    [SerializeField] private GameObject[] otherObjs;
    [SerializeField] private GameObject menuButton;

    public static UnityEvent OnMenuClosed = new UnityEvent();

    public static void SendMenuClosed()
    {
        OnMenuClosed.Invoke();
    }

    public void openPauseMenu()
    {
        menuButton.SetActive(false);

        foreach (var obj in otherObjs)
        {
            obj.SetActive(false);
        }

        pausePanel.SetActive(true);
        Time.timeScale = 0;

        GlobalEventManager.SendUIClcked();
    }

    public void Resume()
    {
        pausePanel.SetActive(false);
        menuButton.SetActive(true);

        foreach (var obj in otherObjs)
        {
            if (obj.name != "SkillsMenu")
            {
                obj.SetActive(true);
            }
        }

        Time.timeScale = 1;

        GlobalEventManager.SendUIClcked();
        SendMenuClosed();
    }

    public void Menu()
    {
        GlobalEventManager.SendUIClcked();

        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1;
    }
}
