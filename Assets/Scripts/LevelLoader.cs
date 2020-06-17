using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class LevelLoader : MonoBehaviour
{
    [SerializeField] private Transform areaTransform;
    [SerializeField] private Image board;
    [SerializeField] private float animationDelay = 2.0f;

    void Start()
    {
        StartCoroutine("PutBoardIntoView");
    }

    void Update()
    {
    }

    private IEnumerator PutBoardIntoView()
    {
        new WaitForSeconds(animationDelay);
        board.transform.SetParent(areaTransform);
        board.transform.position = areaTransform.position;
        yield return new WaitForSeconds(1);
    }
}
