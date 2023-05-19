using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WinPanel : MonoBehaviour
{
    [SerializeField] private GameObject[] objsToHide;
    [SerializeField] private Text diamondsText;
    [SerializeField] private TowerStats blueTower;

    public static bool isActive = false;

    private void Start()
    {
        foreach (var obj in objsToHide)
        {
            obj.SetActive(false);
        }

        diamondsText.text = blueTower.GetAddedDiamonds().ToString();

        isActive = true;
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
