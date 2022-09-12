using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{
    public void OnClick_MainMenu()
    {
        GameManager.AddCoinsIntoPlayerData();
        InputManager.OnPauseStarted -= GameManager.instance.PauseGame;
        SceneManager.LoadScene("MainMenuScene");
    }
}
