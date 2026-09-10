using TMPro;
using UnityEngine;

public class HudScore : MonoBehaviour
{
    [SerializeField] public TextMeshProUGUI textScore;
    [SerializeField] public GameManager gameManager;

    private void Awake()
    {
        gameManager = FindAnyObjectByType<GameManager>();

        if (gameManager == null)
        {
            Debug.LogError("HUD NÃO ENCONTROU O GAMEMANAGER!");
        }
        else
        {
            Debug.Log("HUD ENCONTROU: " + gameManager.gameObject.name);
        }
    }

    private void Update()
    {
        while (gameManager == null)
        {
            gameManager = FindAnyObjectByType<GameManager>();
        }

        Debug.Log("HUD pegou: " + gameManager.totalPoints);
        textScore.text = gameManager.totalPoints.ToString();
        
    }
}
