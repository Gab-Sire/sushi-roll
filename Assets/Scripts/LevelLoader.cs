using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class LevelLoader : MonoBehaviour
{
    [SerializeField] private Transform areaTransform;
    [SerializeField] private Image[] baseIngredients;
    [SerializeField] private float animationDelay = 2.0f;

    private IEnumerator coroutine;

    void Start()
    {
        Debug.Log("Putting base ingredients unto area");
        StartCoroutine("PutBaseIngredientUntoArea");
    }

    void Update()
    {
    }

    private IEnumerator PutBaseIngredientUntoArea()
    {
        new WaitForSeconds(animationDelay);

        foreach (var baseIngredient in baseIngredients)
        {
            Debug.Log("baseIngredient: " + baseIngredient.name);
            baseIngredient.transform.position = areaTransform.position;
            yield return new WaitForSeconds(animationDelay);
        }   
    }
}
