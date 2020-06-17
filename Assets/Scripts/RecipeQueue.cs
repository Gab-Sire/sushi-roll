using System.Collections.Generic;
using UnityEngine;


public class RecipeQueue : MonoBehaviour
{
    // Positioning values - Hand written for now
    private float recipeViewLenght = 100;

    int test = 0;

    [SerializeField]
    GameObject recipeViewPrefab = null;

    List<GameObject> recipeViewList = new List<GameObject>();

    // Update is called once per frame
    void FixedUpdate()
    {
        if (test == 200)
        {
            AddRecipeView(null);
            test = 0;
            randomCompleteOrder();
        }
        test += 1;
    }

    // Test purpose
    void randomCompleteOrder()
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
        recipeViewList.Add(recipeViewObject);
    }
}
