using System;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SpecialUpgrade : MonoBehaviour
{
    [SerializeField] string objectId;
    [SerializeField] float timerBonus;
    [SerializeField] int pointBonus;
    [SerializeField] float speedBonus;
    [SerializeField] float barPoints;

    [Header("Valores e compras")]
    [SerializeField] int requireLevel;
    [SerializeField] int value;
    [SerializeField] int intBuyied;
    [SerializeField] bool isBuyied;

    [SerializeField] Upgrades[] upgrades;

    [Header("Componentes externos")]
    [SerializeField] GameManager gameManager;
    [SerializeField] SustentoBar sustentoBar;
    [SerializeField] public GameObject empresaBoa;
    [SerializeField] public GameObject empresaRuim;
    [SerializeField] GameObject canBuy;
    [SerializeField] TextMeshProUGUI valueText;

    private void Awake()
    {
        upgrades = FindObjectsByType<Upgrades>(FindObjectsSortMode.None);
        sustentoBar = FindAnyObjectByType<SustentoBar>();
        gameManager =FindAnyObjectByType<GameManager>();
        intBuyied = PlayerPrefs.GetInt(objectId + "isBuyied", intBuyied);

        if (intBuyied == 1)
        {
            isBuyied = true;
            empresaBoa.SetActive(true);
            empresaRuim.SetActive(false);
            canBuy.SetActive(false);
            valueText.text = "Valor: COMPRADO";

        }
        else
        {
            canBuy.SetActive(true);
            isBuyied = false;
            empresaBoa.SetActive(false);
            empresaRuim.SetActive(true);
            valueText.text = "Valor: " + value;
        }
    }
    private void Update()
    {
        AllIsMax();
        canBuy.SetActive(false);
    }
    public void OnClick()
    {
        if ((gameManager.totalPoints >= value) && (AllIsMax()) && !isBuyied)
        {
            gameManager.totalPoints -= value;
            intBuyied = 1;
            isBuyied = true;
            PlayerPrefs.SetInt(objectId + "isBuyied", intBuyied);
            sustentoBar.value += barPoints;
            empresaBoa.SetActive(true);
            empresaRuim.SetActive(false);
            valueText.text = "Valor: COMPRADO";
            foreach (Upgrades upgrades in upgrades)
            {
                upgrades.maxLevel += 5;
            }
        }
    }

    bool AllIsMax()
    {
        foreach (Upgrades upgrade in upgrades)
        {
            if (!upgrade.isMax || upgrade.upgradeLevel < requireLevel)
            {
                Debug.Log("Não estou podendo ser comprado");
                canBuy.SetActive(true);
                return false;
            }
        }

        Debug.Log("Posso ser comprado");
        canBuy.SetActive(false);
        return true;
    }
}
