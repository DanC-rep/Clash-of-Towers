using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelector : MonoBehaviour
{
    private Button[] levels;

    private void Start()
    {
        levels = transform.GetComponentsInChildren<Button>();

        for (int i = 0; i < levels.Length; i++)
        {
            if (i >= PlayerPrefs.GetInt("LevelReached", 1))
            {
                levels[i].interactable = false;
            }
        }
    }

    public void SelectLevel(string level)
    {
        SceneManager.LoadScene(level);
    }
}