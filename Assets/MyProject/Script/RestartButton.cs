using UnityEngine;
using UnityEngine.UI;

public class RestartButton : MonoBehaviour
{
    [SerializeField] Timer timer;

    private void Awake()
    {
        timer = FindAnyObjectByType<Timer>();
    }

    public void OnClick()
    {
        timer.currentTime = 0;
    }
}
