using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "Recipe", order = 1)]
public class ScriptableRecipe : ScriptableObject
{
    [SerializeField] public string recipeName = "New order name";
    [SerializeField] public ScriptableIngredient[] ingredients;
}