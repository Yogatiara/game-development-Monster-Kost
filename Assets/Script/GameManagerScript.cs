using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject winTheGame, gameOver;



    public void PopUpwinTheGame()
    {
        winTheGame.SetActive(true);
    }

    public void GameOverPopup()
    {
        gameOver.SetActive(true);
    }
}
