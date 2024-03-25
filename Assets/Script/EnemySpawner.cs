using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    // Start is called before the first frame update

    public float spawnRate = 1f;
    public GameObject[] enemyPrefabs;

    public bool canSpawn = true;

    void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    // Update is called once per frame
    IEnumerator SpawnEnemy()
    {
        WaitForSeconds wait = new WaitForSeconds(spawnRate);

        while (canSpawn)
        {
            yield return wait;
            int random = Random.Range(0, enemyPrefabs.Length);
            GameObject enemyToSpawn = enemyPrefabs[random];


            Instantiate(enemyToSpawn, transform.position, Quaternion.identity);
        }
    }
}
