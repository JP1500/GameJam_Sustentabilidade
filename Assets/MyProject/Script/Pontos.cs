using UnityEngine;
using TMPro;

public class Pontos : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI pontos;
    [SerializeField] TextMeshProUGUI trashCollectedText;

    public int trashCollected;
    public int score;
    public static Pontos instance;
    [SerializeField] GameManager gameManager;

    private void Awake()
    {
        gameManager = FindAnyObjectByType<GameManager>();
        instance = this;
        UpdateScore();
        score = 0;
    }
    public void AddScore()
    {
        trashCollected++;
        score += 1 + gameManager.pointBonus;
        gameManager.points += 1 + gameManager.pointBonus;

        Debug.Log("Pontos: " + score);

        UpdateScore();
    }
    void UpdateScore()
    {
        pontos.text = score.ToString("00");
        trashCollectedText.text = trashCollected.ToString("00");
    }

  private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("lixo"))
        {
            AddScore();
        }
    }
}

