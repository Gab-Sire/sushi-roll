using System.Collections.Generic;
using UnityEngine;

public class RecipeQueue : MonoBehaviour
{
    // Positioning values - Hand written for now
    private float recipeViewLenght = 100;

    int test = 0;

    [SerializeField] private GameObject recipeViewPrefab = null;
    private List<GameObject> recipeViewList = new List<GameObject>();

    void Start()
    {
        LevelManager.GetSelfInstance().newSushiEvent.AddListener(AddRecipeView);
    }

    // Test purpose
    void RandomCompleteOrder()
    {
        if (Random.Range(0, 5) >= 3)
        {
            int randomNb = Random.Range(0, recipeViewList.Count);
            GameObject recipeViewObject = recipeViewList[randomNb];
            if (recipeViewObject != null)
            {
                recipeViewObject.GetComponent<RecipeView>().ExitScene();
                recipeViewList.RemoveAt(randomNb);
            }
        }
    }

    void AddRecipeView(Sushi sushi)
    {
        GameObject recipeViewObject = Instantiate(
            recipeViewPrefab,
            transform.position,
            Quaternion.identity
        );
        recipeViewObject.transform.SetParent(transform);
        recipeViewObject.transform.localPosition = new Vector3(-400, 0, 0);
        recipeViewObject.GetComponent<RecipeView>().EnterScene();
        recipeViewObject.GetComponent<RecipeView>().SetSushi(sushi);
        recipeViewList.Add(recipeViewObject);
    }
}
