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

    [Header("Configurações de acessibilidade")]
    [SerializeField] public bool rightSide;

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

        totalPoints = PlayerPrefs.GetInt("totalPoints", totalPoints);
        timerBonus = PlayerPrefs.GetFloat("TimerBonus", 0);
        speedBonus = PlayerPrefs.GetFloat("SpeedBonus", 0);
        pointBonus = PlayerPrefs.GetInt("PointBonus", 0);

    }
    public void AddPoints(int amount)
    {
        totalPoints += amount;
        PlayerPrefs.SetInt("totalPoints", totalPoints);
        PlayerPrefs.Save();
    }
}
