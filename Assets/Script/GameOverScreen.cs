
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameOverScreen : MonoBehaviour
{
	// Start is called before the first frame update
	public void PlayGame()
	{
		SceneManager.LoadSceneAsync(1);
	}

	public void BackToMenu()
	{
		SceneManager.LoadSceneAsync(0);
	}


}
