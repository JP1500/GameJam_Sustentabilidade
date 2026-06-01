using Unity.VisualScripting;
using UnityEngine;

public class Upgrades : MonoBehaviour
{
    [Header("ID do objeto")]
    [SerializeField] string objectId;

    [Header("Valor do upgrade")]
    [SerializeField] int value;

    [Header("Nivel do upgrade")]
    [SerializeField] int upgradeLevel;

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
        gameManager = FindAnyObjectByType<GameManager>();

        upgradeLevel =PlayerPrefs.GetInt(objectId + "upgradeLevel", upgradeLevel);
        value = PlayerPrefs.GetInt(objectId + "upgradeValue", value);
    }

    public void OnClick()
    {

        if (gameManager.totalPoints >= value)
        {
            gameManager.totalPoints -= value;
            IncreaseValue();

            gameManager.timerBonus += timerBonus;
            gameManager.pointBonus += pointBonus;
            gameManager.speedBonus += speedBonus;
            upgradeLevel++;

            PlayerPrefs.SetInt(objectId + "upgradeLevel", upgradeLevel);
            PlayerPrefs.SetInt(objectId + "upgradeValue", value);

            PlayerPrefs.SetFloat("TimerBonus", gameManager.timerBonus);
            PlayerPrefs.SetFloat("SpeedBonus", gameManager.speedBonus);
            PlayerPrefs.SetInt("PointBonus", gameManager.pointBonus);
            PlayerPrefs.Save();
        }
    }

    public void IncreaseValue()
    {
            float floatValue = value.ConvertTo<float>();
            floatValue = floatValue * multiplierValue;
            value = value + floatValue.ConvertTo<int>();        
    }
}
