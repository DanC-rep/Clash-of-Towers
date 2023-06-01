using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Pause : MonoBehaviour
{
    [SerializeField] private GameObject pausePanel;
    [SerializeField] private GameObject[] otherObjs;

    public void openPauseMenu()
    {
        foreach (var obj in otherObjs)
        {
            obj.SetActive(false);
        }

        pausePanel.SetActive(true);
        Time.timeScale = 0;
    }

    public void Resume()
    {
        pausePanel.SetActive(false);

        foreach (var obj in otherObjs)
        {
            obj.SetActive(false);
        }

        Time.timeScale = 1;
    }

    public void Menu()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1;
    }
}
