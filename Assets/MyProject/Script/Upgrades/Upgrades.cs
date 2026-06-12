using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Upgrades : MonoBehaviour
{
    [Header("ID do objeto")]
    [SerializeField] string objectId;

    [Header("Valor do upgrade e texto")]
    [SerializeField] int value;
    [SerializeField] TextMeshProUGUI valueText;

    [Header("Nivel do upgrade")]
    [SerializeField] public int upgradeLevel;
    [SerializeField] public int maxLevel;
    [SerializeField] public bool isMax;

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
        valueText.text = "Value:" + value;
    }

    private void Update()
    {
        if (upgradeLevel == maxLevel)
        {
            isMax = true;
            valueText.text = "Value: MAXIMO";
        }
        else
        {
            isMax = false;
            valueText.text = "Value:" + value;
        }
    }

    public void OnClick()
    {

        if ((gameManager.totalPoints >= value) && (!isMax))
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
