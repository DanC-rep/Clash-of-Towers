using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WinPanel : MonoBehaviour
{
    [SerializeField] private GameObject[] objsToHide;
    [SerializeField] private GameObject elParent;
    [SerializeField] private Text diamondsText;
    [SerializeField] private TowerStats blueTower;
    [SerializeField] private string nextLevel;
    [SerializeField] private AudioSource winSound;


    private void Start()
    {
        GlobalEventManager.OnTowerDestroy.AddListener(ActivePanel);
    }

    private void ActivePanel(string towerName)
    {
        if (towerName == "BlueTower")
        {
            elParent.SetActive(true);

            foreach (var obj in objsToHide)
            {
                obj.SetActive(false);
            }

            diamondsText.text = blueTower.GetAddedDiamonds().ToString();

            winSound.Play();
        }
    }

    public void NextLevel()
    {
        GlobalEventManager.SendUIClcked();

        SceneManager.LoadScene(nextLevel);
    }

    public void Exit()
    {
        GlobalEventManager.SendUIClcked();

        SceneManager.LoadScene(1);
    }
}
