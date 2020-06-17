using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class LevelManager: MonoBehaviour
{
    [SerializeField] private Transform areaTransform;
    [SerializeField] private Image board;
    [SerializeField] private float animationDelay = 2.0f;

    private List<Sushi> sushiTypes;
    private List<Sushi> orderedSushis = new List<Sushi>();
    private List<Sushi> unfinishedSushis = new List<Sushi>();
    private List<string> assembledIngredients = new List<string>();

    private void Start()
    {
        sushiTypes = InitializeSushiTypes();
        CreateNewSushi();
        CreateNewSushi();

        StartCoroutine("PutBoardIntoView");
    }

    private List<Sushi> InitializeSushiTypes()
    {
        List<Sushi> sushis = new List<Sushi>();

        Sushi philadelphia = new Sushi();
        Sushi boston = new Sushi();
        Sushi spicyTuna = new Sushi();
        Sushi california = new Sushi();
        Sushi dragonRoll = new Sushi();

        List<string> ingredients = new List<string>(){ "salmon", "avocado", "creamCheese" };
        philadelphia.Ingredients = ingredients;

        ingredients = new List<string>() { "shrimp", "avocado", "cucumber" };
        boston.Ingredients = ingredients;

        ingredients = new List<string>() { "tuna", "spicyMayo"};
        spicyTuna.Ingredients = ingredients;

        ingredients = new List<string>() { "crab", "avocado", "cucumber"};
        california.Ingredients = ingredients;

        ingredients = new List<string>() { "eel", "crab", "cucumber", "eelSauce"};
        dragonRoll.Ingredients = ingredients;

        sushis.Add(philadelphia);
        sushis.Add(boston);
        sushis.Add(spicyTuna);
        sushis.Add(california);
        sushis.Add(dragonRoll);

        return sushis;
    }

    private void CreateNewSushi()
    {
        Sushi sushi = sushiTypes[Random.Range(0, sushiTypes.Count)];
        orderedSushis.Add(sushi);
    }

    private IEnumerator PutBoardIntoView()
    {
        new WaitForSeconds(animationDelay);
        board.transform.SetParent(areaTransform);
        board.transform.position = areaTransform.position;
        yield return new WaitForSeconds(1);
    }

    public void AddIngredient(string ingredient)
    {
        assembledIngredients.Add(ingredient);
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
            if (sushi.Ingredients.Count == assembledIngredients.Count)
            {
                foreach (string ingredient in sushi.Ingredients)
                {
                    if (!assembledIngredients.Contains(ingredient))
                    {
                        isMatch = false;
                        break;
                    }
                }
                if(isMatch){
                    orderedSushis.Remove(sushi);
                    return;
                }
            }
        }
    }
}
