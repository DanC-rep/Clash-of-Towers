using UnityEngine;
using UnityEngine.SceneManagement;

public class LosePanel : MonoBehaviour
{
    [SerializeField] private GameObject[] objsToHide;

    private void Start()
    {
        foreach (var obj in objsToHide)
        {
            obj.SetActive(false);
        }

        Time.timeScale = 0;
    }

    public void Restart()
    {
        SceneManager.LoadScene(0);
    }

    public void Exit()
    {
        SceneManager.LoadScene(1);
    }
}
