using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class FimVideo : MonoBehaviour
{
    [SerializeField] float timeToFade;

    [SerializeField] ChangeScene changeScene;
    [SerializeField] GameObject transition;
    void Start()
    {
        changeScene = GetComponent<ChangeScene>();

        StartCoroutine(StartFadeAfterTime());
    }

    IEnumerator StartFadeAfterTime()
    {
        yield return new WaitForSeconds(timeToFade);

        transition.SetActive(true);
        changeScene = FindAnyObjectByType<ChangeScene>();

        changeScene.StartFade();
    }
}