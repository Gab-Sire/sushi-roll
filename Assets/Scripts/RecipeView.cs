using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecipeView : MonoBehaviour
{
    public int speed = 1;

    private GameObject endOfQueueObject;
    private bool hasEnter = false;
    private bool exit = false;
    private int destroyIn = 100;

    void Start()
    {
        endOfQueueObject = GameObject.Find("End Of Queue");
    }

    void FixedUpdate()
    {
        if (hasEnter)
            transform.Translate(Vector3.right * Time.deltaTime * speed);
        if (exit)
        {
            transform.Translate(Vector3.up * Time.deltaTime * speed * 4);
            destroyIn -= 1;
            if (destroyIn < 0)
                Destroy(gameObject);
        }
        if (CheckAtEnd())
        {
            // This mean the  player didn't complete the order in time
            // Call level manager to report
            Debug.Log("Reach the end !!!!");
        }
    }

    // Will start to fly upward and destroy itself
    public void ExitScene() { exit = true; }

    // Start the translation
    public void EnterScene() { hasEnter = true; }

    public bool CheckAtEnd()
    {

        Debug.Log(endOfQueueObject);
        return (transform.position.x >= endOfQueueObject.transform.position.x);
    }
}
