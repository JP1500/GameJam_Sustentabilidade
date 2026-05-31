using Unity.VisualScripting;
using UnityEngine;

public class Upgrades : MonoBehaviour
{
    [Header("Valor do upgrade")]
    [SerializeField] int value;

    [Header("Bonus do upgrade")]
    [SerializeField] float timerBonus;
    [SerializeField] int pointBonus;
    [SerializeField] float speedBonus;

    [Header("Multiplicadores de valor")]

    [SerializeField] public float multiplierValue;

    [Header("Componentes externos")]
    [SerializeField] public GameManager gameManager;

    private void Awake()
    {
        gameManager = GetComponent<GameManager>();
        gameManager = FindAnyObjectByType<GameManager>();
    }

    public void OnClick()
    {

        if (gameManager.totalPoints >= value)
        {
            IncreaseValue();
            gameManager.totalPoints -= value;
            gameManager.timerBonus += timerBonus;
            gameManager.pointBonus += pointBonus;
            gameManager.speedBonus += speedBonus;
        }
    }

    public void IncreaseValue()
    {
        float floatValue = value.ConvertTo<float>();
        Debug.Log("A" + value);
        floatValue = floatValue * multiplierValue;
        Debug.Log("B" + value);
        Debug.Log("K" + floatValue);
        value = value + floatValue.ConvertTo<int>();
        Debug.Log("C" + value);
        
    }
}
