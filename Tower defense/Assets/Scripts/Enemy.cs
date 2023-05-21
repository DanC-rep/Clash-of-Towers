using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private GameObject[] units;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private Transform parent;
    [SerializeField] private int timeToSpawn;
    [SerializeField] private int startTimetoSpawn;

    private bool canSpawn = true;
    private void Start()
    {
        InvokeRepeating("SpawnUnits", startTimetoSpawn, timeToSpawn);

        GlobalEventManager.OnTowerDestroy.AddListener(StopSpawn);
    }

    private void SpawnUnits()
    {
        if (canSpawn)
        {
            int unitsCol = units.Length;
            int unitNumToSpawn = Random.Range(0, unitsCol);
            GameObject newUnit = Instantiate(units[unitNumToSpawn], spawnPoint.position, spawnPoint.rotation, parent);
            newUnit.transform.position = new Vector3(spawnPoint.position.x, spawnPoint.position.y, 1);
        }
    }

    private void StopSpawn(string towerName)
    {
        canSpawn = false; 
    }
}
