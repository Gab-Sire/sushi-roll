using System.Collections.Generic;
using UnityEngine;

public class RecipeQueue : MonoBehaviour
{
    [SerializeField] private GameObject recipeViewPrefab = null;

    private List<GameObject> recipeViewList = new List<GameObject>();
    // Positioning values - Hand written for now
    private float recipeViewLenght = 100;

    void Start()
    {
        LevelManager.GetSelfInstance().newSushiEvent.AddListener(AddRecipeView);
        LevelManager.GetSelfInstance().doneSushiEvent.AddListener(ExitRecipeView);
    }

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
            Resources.Load($"Sushi Recipe Views/{sushi.name} recipe view") as GameObject,
            transform.position,
            Quaternion.identity
        );
        recipeViewObject.transform.SetParent(transform);
        recipeViewObject.transform.localPosition = new Vector3(-400, 0, 0);
        recipeViewObject.GetComponent<RecipeView>().EnterScene();
        recipeViewObject.GetComponent<RecipeView>().SetSushi(sushi);
        recipeViewList.Add(recipeViewObject);
    }

    void ExitRecipeView(Sushi sushi)
    {
        foreach (GameObject view in recipeViewList)
        {
            if (view != null && view.GetComponent<RecipeView>().Sushi.Equals(sushi))
            {
                view.GetComponent<RecipeView>().ExitScene();
                recipeViewList.Remove(view);
                return;
            }
        }
    }
}
