using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    private GameObject mainMenu;
    private GameObject gameOverMenu;
    private TextMesh lastedText;

    [SerializeField] private LevelManager levelManager;

    float timer = 0;
    int minutesPlayed = 0;

    public void DisplayGameOver()
    {
        lastedText.text = $"You lasted {minutesPlayed} minutes";
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

        timer += Time.deltaTime;
        if ((int)timer % 60 == 0)
            minutesPlayed += 1;
    }
}
