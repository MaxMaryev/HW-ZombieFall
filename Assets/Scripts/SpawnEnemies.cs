using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{
    [SerializeField] private Zombie _zombie;
    [SerializeField] private Transform _spawnPoints;
    [SerializeField] private Transform _attractionPoint;

    private void Start()
    {
        StartCoroutine(SpawnZombies());
    }

    private IEnumerator SpawnZombies()
    {
        bool isSpawning = true;
        int instantiateDelay = 2;

        while (isSpawning)
        {
            Instantiate(_zombie, _spawnPoints.GetChild(Random.Range(0, _spawnPoints.childCount)).position, Quaternion.identity);

            yield return new WaitForSeconds(instantiateDelay);
        }
    }
}
