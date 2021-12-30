using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{
    [SerializeField] private Zombie _zombie;
    [SerializeField] private Transform _spawnPointsParent;
    [SerializeField] private int _zombiesCount;
    [SerializeField] private int _instantiateDelay;

    private void Start()
    {
        StartCoroutine(SpawnZombies());
    }

    private IEnumerator SpawnZombies()
    {
        for (int i = 0; i < _zombiesCount; i++)
        {
            Instantiate(_zombie, _spawnPointsParent.GetChild(Random.Range(0, _spawnPointsParent.childCount)).position, Quaternion.identity);

            yield return new WaitForSeconds(_instantiateDelay);
        }
    }
}
