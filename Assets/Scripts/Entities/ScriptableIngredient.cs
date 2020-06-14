using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Data", menuName = "Ingredient", order = 1)]
public class ScriptableIngredient : ScriptableObject
{
    [SerializeField]
    public IngredientEnum category;
    [SerializeField]
    public Sprite icon;
    [SerializeField]
    public Sprite assemblageSprite;
}
