using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private GameObject[] units;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private Transform parent;
    [SerializeField] private int timeToSpawn;
    [SerializeField] private int startTimetoSpawn;

    private void Start()
    {
        InvokeRepeating("spawnUnits", startTimetoSpawn, timeToSpawn);
    }

    private void spawnUnits()
    {
        int unitsCol = units.Length;
        int unitNumToSpawn = Random.Range(0, unitsCol);
        GameObject newUnit = Instantiate(units[unitNumToSpawn], spawnPoint.position, spawnPoint.rotation, parent);
        newUnit.transform.position = new Vector3(spawnPoint.position.x, spawnPoint.position.y, 1);
    }
}
