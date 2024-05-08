
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameOverScreen : MonoBehaviour
{
	// Start is called before the first frame update

	public EnemyMovement enemyMovement;
	public void PlayGame()
	{
		enemyMovement = FindObjectOfType<EnemyMovement>();
		EnemyMovement.enemies = 0;

		SceneManager.LoadSceneAsync(1);
	}

	public void BackToMenu()
	{
		SceneManager.LoadSceneAsync(0);
	}


}
