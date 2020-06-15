using System.Collections.Generic;

public class OrderItem
{
    private bool isSuccess = false;
    private string recipeName;

    /// <summary>
    /// The amount of remaining ingredients in each category to put in order to complete the item
    /// </summary>
    public readonly IDictionary<IngredientEnum, int> remainingIngredients = new Dictionary<IngredientEnum, int>() {
        { IngredientEnum.SALMON, 0},
        { IngredientEnum.SHRIMP, 0},
        { IngredientEnum.TUNA, 0},
        { IngredientEnum.CRAB, 0},
        { IngredientEnum.EEL, 0},
        { IngredientEnum.AVOCADO, 0},
        { IngredientEnum.CUCUMBER, 0},
        { IngredientEnum.CARROT, 0},
        { IngredientEnum.CHEESE_CREAM, 0},
        { IngredientEnum.SPICY_MAYO, 0},
        { IngredientEnum.EEL_SAUCE, 0},
    };

    public OrderItem(string recipeName)
    {
        this.recipeName = recipeName;
    }

    public int this[IngredientEnum category]
    {
        get { return remainingIngredients[category]; }

        set { remainingIngredients[category] = value; }
    }

    public void PutIngredient(IngredientEnum category)
    {
        remainingIngredients[category]--;
    }

    /// <summary>
    /// Check if every ingredient has been put down correctly
    /// Cache order item status for future reference
    /// </summary>
    /// <returns>True if remainingIngredients in each category = 0, false otherwise</returns>
    public bool CheckIfSuccess()
    {
        isSuccess = true;

        foreach (KeyValuePair<IngredientEnum, int> ingredient in remainingIngredients)
        {
            if (ingredient.Value != 0)
            {
                isSuccess = false;
                break;
            }
        }
        return isSuccess;
    }

    public override string ToString()
    {
        int ingredientsTotal = 0;

        foreach (KeyValuePair<IngredientEnum, int> ingredient in remainingIngredients)
        {
            ingredientsTotal += ingredient.Value;
        }

        return "recipeName: " + recipeName
            + " , total of ingredients: " + ingredientsTotal;
    }
}
