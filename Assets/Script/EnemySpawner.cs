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
    public GameObject enemyToSpawn;

    public static int manyEnemies = 0;

    private EnemyMovement enemyMovement;

    public List<int> enemyList = new List<int>();

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
            // string listString = string.Join(", ", enemyList);

            // // Mencetak string yang berisi isi list ke konsol Unity
            // Debug.Log("Isi List: " + listString);

            Instantiate(enemyToSpawn, transform.position, Quaternion.identity);

            // Debug.Log(EnemyMovement.isAnimatingDeath);
            Debug.Log(enemyList.Count);


            // Debug.Log("Many Enemies" + " " + manyEnemies);

            // if (EnemyMovement.isAnimatingDeath)
            // {
            //     maxEnemies--;


            // }
            enemyList.Add(manyEnemies);

            if (manyEnemies == enemies)
            {
                enemyToSpawn = null;
                break;
            }





        }
    }
}
