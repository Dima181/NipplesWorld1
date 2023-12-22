using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject zombiePrefab = null;
    [SerializeField] private float currentSpawnInterval = 0;
    [SerializeField] private int countSpawnPrefabs = 0;

    private void Start()
    {
        StartCoroutine(SpawnZombies());
    }

    IEnumerator SpawnZombies()
    {
        yield return new WaitForSeconds(currentSpawnInterval);

        for (int i = 0; i < countSpawnPrefabs; i++)
        {
            Instantiate(zombiePrefab, gameObject.transform.position, gameObject.transform.rotation);
        }

    }
}
