using UnityEngine;

public class CookingTitle : MonoBehaviour
{
    private Animation animation;

    void Start()
    {
        animation = GetComponent<Animation>();
        animation.Play("cooking_intro");
    }
  void Update()
    {
        
    }
}
