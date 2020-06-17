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
            Image newIngredient = Instantiate(ingredientImg, areaTransform);
            newIngredient.transform.position = areaTransform.position;

        }
    }
}
