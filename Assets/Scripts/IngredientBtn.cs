using UnityEngine;
using UnityEngine.UI;

public class IngredientBtn : MonoBehaviour
{
    [SerializeField] private Transform areaTransform;
    [SerializeField] private Image[] ingredientImgs;

    void Start()
    {

    }

    void Update()
    {
        
    }

    public void PositionImgsUntoArea()
    {
        Debug.Log("Area transform: " + areaTransform.position);

        foreach (var ingredientImg in ingredientImgs)
        {
            Debug.Log("ingredient to instantiate: " + ingredientImg.name);
            Image newIngredient = Instantiate(ingredientImg, areaTransform);
            newIngredient.transform.position = areaTransform.position;
            Debug.Log("Pressed mouse upon area: " + transform.parent.name);
            Debug.Log("Ingredient image initial position: " + newIngredient.transform.position);
            Debug.Log("Ingredient image final position: " + newIngredient.transform.position);
        }
    }
}
