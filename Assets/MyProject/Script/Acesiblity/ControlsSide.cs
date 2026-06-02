using UnityEngine;

public class ControlsSide : MonoBehaviour
{
    [SerializeField] GameManager gameManager;

    [SerializeField] RectTransform restart;
    [SerializeField] RectTransform battery;
    [SerializeField] RectTransform controls;
    void Awake()
    {
        restart = GetComponent<RectTransform>();
        battery = GetComponent<RectTransform>();
        controls = GetComponent<RectTransform>();

        gameManager = FindAnyObjectByType<GameManager>();


        Debug.Log("RightSide = " + gameManager.rightSide);
        if (!gameManager.rightSide)
        {
            battery.anchoredPosition = new Vector3(-368, 200, 0);

            restart.anchoredPosition = new Vector3(994, 160, 0);
            restart.localScale = new Vector3(-1, 1, 1);

            controls.anchoredPosition = new Vector3(328, 140, 0);
        }
        else
        {
            battery.anchoredPosition = new Vector3(368, 200, 0);

            restart.anchoredPosition = new Vector3(-354, 160, 0);
            restart.localScale = new Vector3(1, 1, 1);

            controls.anchoredPosition = new Vector3(-328, 140, 0);
        }

    }
}