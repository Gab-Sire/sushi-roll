using UnityEngine;
using UnityEngine.UI;

public class IngredientBtn : MonoBehaviour
{
    [SerializeField] private Transform areaTransform;
    [SerializeField] private Image[] ingredientImgs;

    private LevelManager levelManager;
    private string ingredientName;

    void Start()
    {
        levelManager = LevelManager.GetSelfInstance();
    }

    public void PositionImgsUntoArea()
    {
        //Debug.Log("Area transform: " + areaTransform.position);

        foreach (var ingredientImg in ingredientImgs)
        {
            Image newIngredient = Instantiate(ingredientImg);
            newIngredient.transform.SetParent(areaTransform);
            
            Debug.Log("new ingredient: " + newIngredient);
            newIngredient.transform.position = areaTransform.position;
            newIngredient.transform.parent.name = newIngredient.name;
            levelManager.AddIngredient(newIngredient);
        }
    }
}
