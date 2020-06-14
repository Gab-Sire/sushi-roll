using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Customer : MonoBehaviour
{
    private LevelManager levelManager;
    private GameObject location;

    private bool asGiveOrder;

    // Start is called before the first frame update
    void Start()
    {
        levelManager = LevelManager.Instance;
        location = levelManager.GetEmptyLocation();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = levelManager.cashierPosition.transform.position;



    }

}
