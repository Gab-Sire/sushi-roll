using UnityEngine;
using UnityEngine.UI;


public class IngredientCase : MonoBehaviour
{
    [SerializeField] private Transform assemblageAreaTransform;

    private Image ingredient;

    void Start()
    {
        ingredient = GetComponentsInChildren<Image>()[1];
        Debug.Log("Received ingredient object: " + ingredient.name);
        assemblageAreaTransform = GameObject.Find("AssemblageArea").transform;
        Debug.Log("Transform of assemblage area: " + assemblageAreaTransform.position);
    }

    void Update()
    {
        
    }

    public void positionIngredientIntoAssemblage()
    {
        Debug.Log("Pressed mouse upon area: " + gameObject.name);
        ingredient.transform.position = new Vector3(assemblageAreaTransform.position.x, assemblageAreaTransform.position.y, -5);
        ingredient.transform.SetParent(assemblageAreaTransform);
    }
}
