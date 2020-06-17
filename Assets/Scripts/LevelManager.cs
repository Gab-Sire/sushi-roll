using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class LevelManager
{
    // Location 
    public Dictionary<GameObject, GameObject> locations = new Dictionary<GameObject, GameObject>();
    public GameObject cashierPosition = GameObject.Find("CashierPosition");
    private string[] recipeNames;

    private static LevelManager instance = null;
    private Queue<Order> orders { get; }
    private static int orderId = 0;

    public static LevelManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new LevelManager();
            }
            return instance;
        }
    }

    private LevelManager()
    {
        for (int i = 1; i <= 8; i++)
        {
            GameObject location = GameObject.Find($"Location {i}");
            Debug.Log("Name location:" + location.name);
            locations.Add(location, null);
        }

        OrderItemManager.InitializeItemTypes();
        recipeNames = OrderItemManager.GetRecipeNames();

        // for testing purposes

        //Debug.Log("Recipes available:"  + recipeNames.Length);

        int randomIndex = Random.Range(0, recipeNames.Length);
        string testRecipe01 = recipeNames[randomIndex];
        randomIndex = Random.Range(0, recipeNames.Length);
        string testRecipe02 = recipeNames[randomIndex];

        Order testOrder01 = new Order(orderId++);
        OrderItemManager.InjectTemplateItemInOrder(testOrder01, testRecipe01);
        Order testOrder02 = new Order(orderId++);
        OrderItemManager.InjectTemplateItemInOrder(testOrder02, testRecipe02);

        //Debug.Log("Test order 01: " + testOrder01);
        //Debug.Log("Test order 02: " + testOrder02);

        orders = new Queue<Order>();
        orders.Enqueue(testOrder01);
        orders.Enqueue(testOrder02);

        //Debug.Log("number of order queue elements: " + orders.Count);
    }

    public GameObject GetEmptyLocation()
    {
        foreach (var location in locations)
        {
            if (location.Value == null)
                return location.Key;
        }
        return null;
    }
}
