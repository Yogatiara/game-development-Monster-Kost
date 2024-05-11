
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameOverScreen : MonoBehaviour
{
	// Start is called before the first frame update

	public EnemySpawner enemySpawner;

	void Start()
	{
		enemySpawner = FindObjectOfType<EnemySpawner>();
	}
	public void PlayGame()
	{
		EnemySpawner.manyEnemies = 0;
		EnemyMovement.isAnimatingDeath = false;
		// EnemySpawner.maxEnemies = enemySpawner.enemies;


		SceneManager.LoadSceneAsync(1);
	}

	public void BackToMenu()
	{
		EnemySpawner.manyEnemies = 0;

		// EnemySpawner.maxEnemies = enemySpawner.enemies;

		SceneManager.LoadSceneAsync(0);
	}


}
