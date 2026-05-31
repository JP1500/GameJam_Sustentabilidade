using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class HudScore : MonoBehaviour
{
    [SerializeField] public TextMeshProUGUI textScore;
    [SerializeField] public GameManager gameManager;

    private void Awake()
    {
        gameManager = FindAnyObjectByType<GameManager>();
    }
    void Update()
    {
        textScore.text = gameManager.totalPoints.ToString("00");
    }
}
