using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Pause : MonoBehaviour
{
    [SerializeField] private GameObject pausePanel;
    [SerializeField] private GameObject[] otherObjs;
    [SerializeField] private GameObject menuButton;

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
            obj.SetActive(true);
        }

        Time.timeScale = 1;

        GlobalEventManager.SendUIClcked();
    }

    public void Menu()
    {
        GlobalEventManager.SendUIClcked();

        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1;
    }
}
