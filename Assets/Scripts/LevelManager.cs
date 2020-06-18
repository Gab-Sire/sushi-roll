using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using Random = UnityEngine.Random;

public enum GameStatus
{
    ReadyToStart,
    InProgress,
    GameOver
}

[System.Serializable]
public class NewSushiEvent : UnityEvent<Sushi>
{
}

public class LevelManager : MonoBehaviour
{
    [SerializeField] private Transform areaTransform;
    [SerializeField] private Image board;
    [SerializeField] private float animationDelay = 2.0f;

    private List<Sushi> sushiTypes;
    public List<Sushi> orderedSushis = new List<Sushi>();
    private List<Sushi> unfinishedSushis = new List<Sushi>();
    private List<string> assembledIngredients = new List<string>();

    public NewSushiEvent newSushiEvent;
    public GameStatus gameStatus = GameStatus.ReadyToStart;

    private int sushiCreatedIn = 0;
    private int sushiSpeedCreation = 200;

    public void StartGame()
    {
        gameStatus = GameStatus.InProgress;
    }

    private void Start()
    {
        sushiTypes = Constant.sushis;
        newSushiEvent = new NewSushiEvent();
        StartCoroutine("PutBoardIntoView");
        sushiCreatedIn = 0;
        sushiSpeedCreation = 200;
    }

    private void FixedUpdate()
    {
        if (gameStatus != GameStatus.InProgress)
            return;
        if (sushiCreatedIn == sushiSpeedCreation)
        {
            CreateNewSushi();
            sushiCreatedIn = 0;
            sushiSpeedCreation -= 1;
        }
        sushiCreatedIn += 1;
    }

    private void CreateNewSushi()
    {
        Sushi sushi = sushiTypes[Random.Range(0, sushiTypes.Count)];
        orderedSushis.Add(sushi);
        newSushiEvent.Invoke(sushi);
    }

    private IEnumerator PutBoardIntoView()
    {
        new WaitForSeconds(animationDelay);
        board.transform.SetParent(areaTransform);
        board.transform.position = areaTransform.position;
        yield return new WaitForSeconds(1);
    }

    public static LevelManager GetSelfInstance()
    {
        GameObject camera = GameObject.Find("Main Camera");
        return camera.GetComponent("LevelManager") as LevelManager;
    }

    public void AddIngredient(string ingredient)
    {
        assembledIngredients.Add(ingredient);
    }

    public void UnfinishedSushi(Sushi sushi)
    {
        unfinishedSushis.Add(sushi);
        if (unfinishedSushis.Count == 3)
        {
            GameOver();
        }
    }

    public void ClearIngredients()
    {
        assembledIngredients.Clear();
    }

    /// <summary>
    /// Find the first matching sushi against a list of ingredients, and remove it form the ordered sushis
    /// </summary>
    public void CheckMatchedSushi()
    {
        bool isMatch = true;

        foreach (Sushi sushi in orderedSushis)
        {
            if (sushi.ingredients.Count == assembledIngredients.Count)
            {
                foreach (string ingredient in sushi.ingredients)
                {
                    if (!assembledIngredients.Contains(ingredient))
                    {
                        isMatch = false;
                        break;
                    }
                }
                if (isMatch)
                {
                    orderedSushis.Remove(sushi);
                    return;
                }
            }
        }
    }

    private void GameOver()
    {
        gameStatus = GameStatus.GameOver;
    }

}
