using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelector : MonoBehaviour
{
    public void SelectLevel(string level)
    {
        SceneManager.LoadScene(level);
    }
}