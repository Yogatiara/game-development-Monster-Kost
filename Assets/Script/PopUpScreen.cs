
using UnityEngine;
using UnityEngine.SceneManagement;


public class PopUpScreen : MonoBehaviour
{
	// Start is called before the first frame update

	public EnemySpawner enemySpawner;
	public EnemyMovement enemyMovement;
	public int enemies;

	void Start()
	{
		enemySpawner = FindObjectOfType<EnemySpawner>();
		enemySpawner = FindObjectOfType<EnemySpawner>();

	}
	public void PlayGame()
	{
		EnemySpawner.manyEnemies = 0;
		EnemyMovement.isAnimatingDeath = false;
		enemySpawner.enemyList.Clear();
		// EnemySpawner.maxEnemies = enemies;
		// EnemySpawner.maxEnemies = enemySpawner.enemies;


		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}

	public void BackToMenu()
	{
		EnemySpawner.manyEnemies = 0;
		EnemyMovement.isAnimatingDeath = false;

		// EnemySpawner.maxEnemies = enemySpawner.enemies;

		SceneManager.LoadSceneAsync(0);
	}


}
