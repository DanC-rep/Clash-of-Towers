using UnityEngine;
using UnityEngine.SceneManagement;

public class WinPanel : MonoBehaviour
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

    public void NextLevel()
    {
        Debug.Log("Next Level");
    }

    public void Exit()
    {
        SceneManager.LoadScene(1);
    }
}
