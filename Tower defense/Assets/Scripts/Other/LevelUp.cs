using UnityEngine;

public class LevelUp : MonoBehaviour
{
    [SerializeField] private int nextLevel;

    private void Start()
    {
        GlobalEventManager.OnTowerDestroy.AddListener(UpLevel);
    }

    private void UpLevel(string towerName)
    {
        if (towerName == "BlueTower" && nextLevel >= PlayerPrefs.GetInt("LevelReached"))
        {
            PlayerPrefs.SetInt("LevelReached", nextLevel);
        }
    }
}
