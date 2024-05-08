using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    // Start is called before the first frame update

    public float spawnRate = 1f;
    public GameObject[] enemyPrefabs;

    public bool canSpawn = true;

    public int maxEnemies = 5;

    void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    // Update is called once per frame
    IEnumerator SpawnEnemy()
    {
        WaitForSeconds wait = new WaitForSeconds(spawnRate);
        int manyEnemies = 0;
        while (canSpawn)
        {
            manyEnemies += 1;
            yield return wait;
            int random = Random.Range(0, enemyPrefabs.Length);
            GameObject enemyToSpawn = enemyPrefabs[random];



            Instantiate(enemyToSpawn, transform.position, Quaternion.identity);

            if (manyEnemies == maxEnemies)
            {
                break;
            }
        }
    }
}
