using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    // Start is called before the first frame update

    public float spawnRate = 1f;
    public GameObject[] enemyPrefabs;

    public bool canSpawn = true;
    public int enemies = 5;
    public static int maxEnemies;
    private GameObject enemyToSpawn;

    public static int manyEnemies = 0;

    private EnemyMovement enemyMovement;


    void Start()
    {
        maxEnemies = enemies;
        StartCoroutine(SpawnEnemy());
    }

    public void Spawn(bool canSpawning)
    {

        canSpawn = canSpawning;
    }

    // Update is called once per frame
    IEnumerator SpawnEnemy()
    {
        WaitForSeconds wait = new WaitForSeconds(spawnRate);
        while (canSpawn)
        {
            yield return wait;
            int random = Random.Range(0, enemyPrefabs.Length);
            enemyToSpawn = enemyPrefabs[random];

            manyEnemies += 1;

            Instantiate(enemyToSpawn, transform.position, Quaternion.identity);

            enemyMovement = FindObjectOfType<EnemyMovement>();
            Debug.Log(EnemyMovement.isAnimatingDeath);


            // Debug.Log("Many Enemies" + " " + manyEnemies);

            if (EnemyMovement.isAnimatingDeath)
            {
                maxEnemies--;
                Debug.Log("Max Enemies" + " " + maxEnemies);

            }
            if (manyEnemies == enemies)
            {
                enemyToSpawn = null;
                break;
            }





        }
    }
}
