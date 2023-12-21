using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState { Title, InGame, Paused, Gameover } 

public class GameManager : Singleton<GameManager> 
{
    public GameState gameState;

    public void ChangeGameState(GameState _gameState)
    {
        gameState = _gameState;
    }
    
}
