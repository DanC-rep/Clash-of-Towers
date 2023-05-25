using UnityEngine;
using UnityEngine.SceneManagement;

public class LosePanel : MonoBehaviour
{
    [SerializeField] private GameObject[] objsToHide;
    [SerializeField] private GameObject elParent;


    private void Start()
    {
        GlobalEventManager.OnTowerDestroy.AddListener(ActivePanel);
    }

    private void ActivePanel(string towerName)
    {
        if (towerName == "RedTower")
        {
            elParent.SetActive(true);

            foreach (var obj in objsToHide)
            {
                obj.SetActive(false);
            }
        }
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
