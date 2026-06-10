using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class FadeIn : MonoBehaviour
{
    [SerializeField] Image fadeImage;
    [SerializeField] float fadeDuration = 1f;

    private void Awake()
    {
        gameObject.SetActive(true);
    }
    private void Start()
    {
        StartCoroutine(FadeScreen());
    }

    IEnumerator FadeScreen()
    {
        Color color = fadeImage.color;

        while (color.a > 0)
        {
            color.a -= Time.deltaTime / fadeDuration;
            fadeImage.color = color;

            yield return null;
        }

        color.a = 0;
        fadeImage.color = color;
    }
}
