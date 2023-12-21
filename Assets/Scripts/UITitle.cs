using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UITitle : Singleton<UITitle>
{
    public void StartGame()
    {
        SceneManager.LoadScene("TopDown_Main");
        _GM.ChangeGameState(GameState.InGame);
    }

    public void ToTitleScreen()
    {
        SceneManager.LoadScene("TitleScreen");
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    } 

    public void LoadCombatScene()
    {
        SceneManager.LoadScene("CombatUI");
    }

    public void FromCombatScene()
    {
        SceneManager.LoadScene("TopDown_Main");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}
