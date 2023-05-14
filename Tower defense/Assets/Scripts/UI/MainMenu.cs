using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void Play()
    {
        SceneManager.LoadScene(0);
    }

    public void Settings()
    {
        Debug.Log("Settings");
    }

    public void Help()
    {
        Debug.Log("Help");
    }
}
