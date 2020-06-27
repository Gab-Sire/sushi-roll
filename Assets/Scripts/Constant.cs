using System.Collections.Generic;
using UnityEngine;

public class Constant : MonoBehaviour
{

    public static List<Sushi> sushis; // Static List instance
    public static List<string> sushi_names; // Static List instance

    static Constant()
    {
        sushis = new List<Sushi>();
        sushis.Add(new Sushi("philadelphia", new List<string>() { "nori", "rice", "salmon", "avocado", "cheesecream" }));
        sushis.Add(new Sushi("boston", new List<string>() { "nori", "rice", "shrimp", "avocado", "cucumber" }));
        sushis.Add(new Sushi("vegetarian", new List<string>() { "nori", "rice", "carrots", "cucumber", "avocado" }));
        sushis.Add(new Sushi("california", new List<string>() { "nori", "rice", "crab", "avocado", "cucumber" }));
        sushi_names = new List<string>() { "philadelphia", "boston", "spicytuna", "california" };
    }

}
