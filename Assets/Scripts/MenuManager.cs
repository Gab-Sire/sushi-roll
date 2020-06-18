using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    GameObject mainMenu;
    GameObject gameOverMenu;

    LevelManager levelManager;

    public void DisplayGameOver()
    {
        gameOverMenu.SetActive(true);
    }

    public void PlayBtnHandler()
    {
        levelManager.StartGame();
        mainMenu.SetActive(false);
    }

    public void QuitBtnHandler()
    {
        Application.Quit();
    }

    public void BackBtnHandler()
    {
        mainMenu.SetActive(true);
        gameOverMenu.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {
        levelManager = LevelManager.GetSelfInstance();
        mainMenu = GameObject.Find("Main Menu");
        gameOverMenu = GameObject.Find("Game Over Menu");
        mainMenu.SetActive(true);
        gameOverMenu.SetActive(false);

        if (Application.platform != RuntimePlatform.WebGLPlayer)
        {
            GameObject.Find("Quit Btn");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (levelManager.gameStatus == GameStatus.GameOver)
        {
            Debug.Log("Game over menu");
            DisplayGameOver();
            levelManager.gameStatus = GameStatus.ReadyToStart;
        }
    }
}
