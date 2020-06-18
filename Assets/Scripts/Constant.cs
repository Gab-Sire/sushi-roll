using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class Constant : MonoBehaviour
{

    public static List<Sushi> sushis; // Static List instance
    public static List<string> sushi_names; // Static List instance

    static Constant()
    {
        sushis = new List<Sushi>();
        sushis.Add(new Sushi("philadelphia", new List<string>() { "salmon", "avocado", "creamCheese" }));
        sushis.Add(new Sushi("boston", new List<string>() { "shrimp", "avocado", "cucumber" }));
        sushis.Add(new Sushi("spicyTuna", new List<string>() { "tuna", "spicyMayo" }));
        sushis.Add(new Sushi("california", new List<string>() { "crab", "avocado", "cucumber" }));
        sushi_names = new List<string>() { "philadelphia", "boston", "spicyTuna", "california" };
    }

}
