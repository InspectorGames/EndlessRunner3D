using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public static int coinsCollected;
    public static Action OnCoinCollected;

    public GameObject gameOverScreen;
    public static bool gameOver = false;

    public static Action OnRestartGame;

    public GameObject pauseMenu;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    private void Start()
    {
        gameOver = false;
        InputManager.OnPauseStarted += PauseGame;
        Time.timeScale = 1;
        coinsCollected = 0;

    }

    public static void CoinCollected()
    {
        coinsCollected++;
        OnCoinCollected?.Invoke();
    }

    public void PauseGame()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0;
    }

    public static void ResumeGame()
    {
        Time.timeScale = 1;
        InputManager.OnPauseStarted -= ResumeGame;
    }

    public void GameOver()
    {
        gameOverScreen.SetActive(true);
        InputManager.OnPauseStarted -= PauseGame;
        gameOver = true;
    }

    public static void RestartGame()
    {
        OnRestartGame?.Invoke();
        AddCoinsIntoPlayerData();
        coinsCollected = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        gameOver = false;
    }

    public static void AddCoinsIntoPlayerData()
    {
        PlayerData.Instance.AddCoins(coinsCollected);
    }
}
