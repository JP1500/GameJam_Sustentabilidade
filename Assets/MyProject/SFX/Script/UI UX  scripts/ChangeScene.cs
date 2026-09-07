using System.Collections;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    [SerializeField] Image fadeImage;
    [SerializeField] float fadeDuration = 1f;
    [SerializeField] string nextScene;

    [SerializeField] AudioSource audioSource;
    float initialVolume;

    void Awake()
    {
        gameObject.SetActive(false);

        audioSource = FindAnyObjectByType<AudioSource>();

        if (audioSource != null)
        {
            initialVolume = audioSource.volume;
        }
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
            float progress = color.a;

            color.a += Time.deltaTime / fadeDuration;
            fadeImage.color = color;

            if (audioSource != null)
            {
                audioSource.volume = Mathf.Lerp(initialVolume, 0f, progress);
            }

            yield return null;
        }

        if (audioSource != null)
        {
            audioSource.volume = 0f;
        }

        SceneManager.LoadScene(nextScene);
    }
}
