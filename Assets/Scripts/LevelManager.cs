using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager
{
    // Location 
    public Dictionary<GameObject, GameObject> locations = new Dictionary<GameObject, GameObject>();
    public GameObject cashierPosition = GameObject.Find("CashierPosition");

    private static LevelManager instance = null;

    public static LevelManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new LevelManager();
            }
            return instance;
        }
    }

    public GameObject GetEmptyLocation()
    {
        foreach (var location in locations)
        {
            if (location.Value == null)
                return location.Key;
        }
        return null;
    }

    LevelManager()
    {
        for (int i = 1; i <= 8; i++)
        {
            GameObject location = GameObject.Find($"Location {i}");
            Debug.Log("Name location:" + location.name);
            locations.Add(location, null);
        }

    }
}
