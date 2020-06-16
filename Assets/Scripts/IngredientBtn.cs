using System;
using UnityEngine;
using UnityEngine.UI;


public class IngredientBtn : MonoBehaviour
{
    [SerializeField] private Transform areaTransform;
    [SerializeField] private Image ingredientImage;

    void Start()
    {

    }

    void Update()
    {
        
    }

    public void PositionImgUntoArea()
    {
        Debug.Log("Pressed mouse upon area: " + gameObject.name);
        ingredientImage.transform.position = new Vector3(areaTransform.position.x, areaTransform.position.y, -5);
        ingredientImage.transform.SetParent(areaTransform);
    }
}
