using UnityEngine;

public class TowerSpawner : MonoBehaviour
{
    private int towerLevel;

    [SerializeField] private GameObject[] towers;
    [SerializeField] private Transform spawnPoint;

    private void Awake()
    {
        towerLevel = PlayerPrefs.GetInt("towerLevel", 0);

        Instantiate(towers[towerLevel], spawnPoint.position, spawnPoint.rotation, spawnPoint.parent);

        PlayerSettings.instance.SetMoneyPerTime(towers[towerLevel].GetComponent<TowerStats>().GetMoneyPerTime());
    }
}
