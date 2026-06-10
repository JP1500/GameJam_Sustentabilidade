using System.Collections;
using System.Linq;
using UnityEngine;

public class StartGame : MonoBehaviour
{
    [SerializeField] float transitionSpeed;
    [SerializeField] GameObject[] squares;

    private void Awake()
    {
        gameObject.SetActive(true);

        squares = new GameObject[transform.childCount];

        for (int i = 0; i < transform.childCount; i++)
        {
            squares[i] = transform.GetChild(i).gameObject;
        }
    }
    private void Start()
    {
        StartCoroutine(OpenPanel());
    }

    IEnumerator OpenPanel()
    {
        squares = squares.OrderBy(x => Random.value).ToArray();
        foreach (GameObject square in squares)
        {
            square.SetActive(false);

            yield return new WaitForSeconds(transitionSpeed);
        }

        gameObject.SetActive(false);
    }
}
