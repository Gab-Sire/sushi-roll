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

[System.Serializable]
public class DoneSushiEvent : UnityEvent<Sushi>
{
}

public class LevelManager : MonoBehaviour
{
    public NewSushiEvent newSushiEvent;
    public DoneSushiEvent doneSushiEvent;

    [SerializeField] private Transform areaTransform;
    [SerializeField] private Image board;
    [SerializeField] private float animationDelay = 2.0f;

    private List<Sushi> sushiTypes;
    public List<Sushi> orderedSushis = new List<Sushi>();
    public List<Sushi> completedSushis = new List<Sushi>();
    private List<Sushi> unfinishedSushis = new List<Sushi>();
    private List<string> assembledIngredients = new List<string>();
    private List<Image> ingredientImgs = new List<Image>();

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
        doneSushiEvent = new DoneSushiEvent();
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

    public void AddIngredient(Image ingredientImg)
    {
        if (ingredientImg.CompareTag("ingredient"))
        {
            string ingredientName = ingredientImg.transform.parent.name.Substring(0, ingredientImg.transform.parent.name.IndexOf("_")).ToLower();
            assembledIngredients.Add(ingredientName);
            Debug.Log("Added ingredient: " + ingredientName);
            ingredientImgs.Add(ingredientImg);
        }
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

        foreach (Image img in ingredientImgs)
        {
            Destroy(img);
        }
        ingredientImgs.Clear();
        //Debug.Log("Ingredients cleared");
    }

    /// <summary>
    /// Find the first matching sushi against a list of ingredients, and remove it form the ordered sushis
    /// </summary>
    public void CheckMatchedSushi()
    {
        //Debug.Log("Checking if a sushi matches..");
        bool isMatch = true;

        foreach (Sushi sushi in orderedSushis)
        {
            isMatch = true;
            
            //Debug.Log("sushi ingredients count for matching: " + sushi.ingredients.Count);
            //Debug.Log("assembled ingredients count for matching: " + assembledIngredients.Count);

            if (sushi.ingredients.Count == assembledIngredients.Count)
            {
                foreach (string ingredient in sushi.ingredients)
                {
                    string result = "";

                    foreach (string ing in assembledIngredients)
                    {
                        result += " / " + ing;
                    }
                    // Debug.Log("assembled ingredients: " + result);

                    if (!assembledIngredients.Contains(ingredient))
                    {
                        isMatch = false;
                        break;
                    }
                }
            }

            if (isMatch)
            {
                //Debug.Log("**** sushi is matched");
                CompleteSushi(sushi);
                ClearIngredients();
                return;
            }
        }
    }

    public void CompleteSushi(Sushi sushi)
    {
        completedSushis.Add(sushi);
        orderedSushis.Remove(sushi);
        doneSushiEvent.Invoke(sushi);
    }

    private void GameOver()
    {
        gameStatus = GameStatus.GameOver;
    }

}
