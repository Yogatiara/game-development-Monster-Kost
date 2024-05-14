using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
  // Start is called before the first frame update

  public GameObject credit;

  public void PlayGame()
  {
    SceneManager.LoadSceneAsync(1);
  }

  public void Credit()
  {
    credit.SetActive(true);
  }
  public void BackToMenu()
  {
    credit.SetActive(false);
  }



  public void Exit()
  {
    Application.Quit();
  }



  // Update is called once per frame
  // void Update()
  // {

  // }
}
