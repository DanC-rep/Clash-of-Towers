using UnityEngine;
using UnityEngine.SceneManagement;

public class LosePanel : MonoBehaviour
{
    [SerializeField] private GameObject[] objsToHide;
    [SerializeField] private GameObject elParent;
    [SerializeField] private AudioSource loseSound;


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

            loseSound.Play();
        }
    }

    public void Restart()
    {
        GlobalEventManager.SendUIClcked();

        SceneManager.LoadScene(0);
    }

    public void Exit()
    {
        GlobalEventManager.SendUIClcked();

        SceneManager.LoadScene(1);
    }
}
