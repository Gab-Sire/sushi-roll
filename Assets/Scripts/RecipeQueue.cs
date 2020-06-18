using System.Collections.Generic;
using UnityEngine;

public class RecipeQueue : MonoBehaviour
{
    // Positioning values - Hand written for now
    private float recipeViewLenght = 100;

    [SerializeField] private GameObject recipeViewPrefab = null;
    private List<GameObject> recipeViewList = new List<GameObject>();

    void Start()
    {
        LevelManager.GetSelfInstance().newSushiEvent.AddListener(AddRecipeView);
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
}
