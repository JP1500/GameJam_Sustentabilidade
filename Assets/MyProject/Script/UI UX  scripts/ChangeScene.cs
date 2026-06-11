using System.Collections;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    [SerializeField] Image fadeImage;
    [SerializeField] float fadeDuration = 1f;
    [SerializeField] string nextScene;

    void Awake()
    {
        gameObject.SetActive(false);
    }
    public void StartFade()
    {
        gameObject.SetActive(true);
        StartCoroutine(FadeScreen());
    }

    IEnumerator FadeScreen()
    {
        Color color = fadeImage.color;

        while (color.a < 1)
        {
            color.a += Time.deltaTime / fadeDuration;
            fadeImage.color = color;

            yield return null;
        }

        SceneManager.LoadScene(nextScene);
    }
}
