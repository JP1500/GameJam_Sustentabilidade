using UnityEngine;
using TMPro;
using System.Collections.Generic;

public class Pontos : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI pontos;
    [SerializeField] TextMeshProUGUI trashCollectedText;

    public int trashCollected;
    public int score;
    public static Pontos instance;
    [SerializeField] GameManager gameManager;

    [SerializeField] AudioSource coletarSom;

    private void Awake()
    {
        gameManager = FindAnyObjectByType<GameManager>();
        instance = this;
        UpdateScore();
        score = 0;
    }
    public void AddScore()
    {
        Debug.Log("Adicionando ponto");

        trashCollected++;

        int ganho = 1 + gameManager.pointBonus;

        score += ganho;

        gameManager.AddPoints(ganho);

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
            coletarSom.Play();
        }
    }
}

