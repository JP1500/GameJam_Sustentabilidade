using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class GameManager : MonoBehaviour
{
    [Header("Pontos")]
    [SerializeField] public int totalPoints;
    [SerializeField] public int points;

    public static GameManager instance;

    [Header("Atributos upgradeados pro player")]
    [SerializeField] public float timerBonus;
    [SerializeField] public int pointBonus;
    [SerializeField] public float speedBonus;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;

            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        
    }

    private void Update()
    {
        if (points != 0)
        {
            totalPoints += points;
            points = 0;
        }
    }
}
