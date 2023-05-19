using UnityEngine;
using UnityEngine.SceneManagement;

public class LosePanel : MonoBehaviour
{
    [SerializeField] private GameObject[] objsToHide;

    public static bool isActive = false;

    private void Start()
    {
        foreach (var obj in objsToHide)
        {
            obj.SetActive(false);
        }

        isActive = true;
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
