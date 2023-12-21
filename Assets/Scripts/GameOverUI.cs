using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverUI : MonoBehaviour
{
    
    public GameObject gameOverPanel;
    private bool gameOver;

    private void Start()
    {
        
        gameOverPanel.SetActive(false);

    }

    void WinGame()
    {

        gameOver = true;
        gameOverPanel.SetActive(true);

        

    }

}
