using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject _zombie;
    [SerializeField] private Transform _spawn;
    private Transform[] _spawnPoints;
    [SerializeField] private Transform _attractionPoint;

    void Start()
    {
        _spawnPoints = new Transform[_spawn.childCount];

        for (int i = 0; i < _spawn.childCount; i++)
        {
            _spawnPoints[i] = _spawn.GetChild(i);
        }

        StartCoroutine(SpawnZombies());
    }

    private IEnumerator SpawnZombies()
    {
        bool isSpawning = true;

        while (isSpawning)
        {
            Instantiate(_zombie, _spawnPoints[Random.Range(0, _spawn.childCount)].position, Quaternion.identity);

            yield return new WaitForSeconds(2);
        }
    }
}
