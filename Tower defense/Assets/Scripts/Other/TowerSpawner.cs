using UnityEngine;

public class TowerSpawner : MonoBehaviour
{
    private int towerLevel;

    [SerializeField] private GameObject[] towers;
    [SerializeField] private Transform spawnPoint;

    private void Start()
    {
        towerLevel = PlayerPrefs.GetInt("towerLevel", 0);

        Instantiate(towers[towerLevel], spawnPoint.position, spawnPoint.rotation, spawnPoint.parent);
    }
}
