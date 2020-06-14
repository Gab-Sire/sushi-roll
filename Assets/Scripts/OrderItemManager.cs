using System;
using System.Collections.Generic;
using UnityEngine;

public static class OrderItemManager
{
    private static ScriptableRecipe[] recipes = Resources.FindObjectsOfTypeAll<ScriptableRecipe>();

    private static Dictionary<string, OrderItem> mappedOrderRecipes = new Dictionary<string, OrderItem>();

    /// <summary>
    /// Map every order item types at game start for caching
    /// ScriptableObject recipe data assets -> order item to inject into orders
    /// </summary>
    public static void InitializeItemTypes()
    {
        Debug.Log("Resources found during initialization: " + recipes.Length);
        //Debug.Log("Example of resource found: " + recipes[0].name);

        Array.ForEach(recipes, recipe =>
        {
            OrderItem item = new OrderItem(recipe.name);

            // map ingredients quantities based on occurence number of the ingredient in the recipe
            Array.ForEach(recipe.ingredients, ingredient =>
            {
                item.remainingIngredients[ingredient.category]++;
            });
            mappedOrderRecipes.Add(recipe.name, item);
        });
    }

    public static void InjectTemplateItemInOrder(Order order, string recipeName)
    {
        order.AddItem(mappedOrderRecipes[recipeName]);
    }

    public static string[] GetRecipeNames()
    {
        string[] recipeNames = new string[recipes.Length];

        for (int i = 0; i < recipes.Length; i++)
        {
            recipeNames[i] = recipes[i].name;
        }
        return recipeNames;
    }
}
