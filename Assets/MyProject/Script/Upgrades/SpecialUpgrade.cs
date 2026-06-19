using System;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

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
    [SerializeField] public GameObject[] empresaBoa;
    [SerializeField] public GameObject[] empresaRuim;
    [SerializeField] GameObject canBuy;
    [SerializeField] TextMeshProUGUI valueText;

    private void Awake()
    {
        upgrades = FindObjectsByType<Upgrades>(FindObjectsSortMode.None);
        sustentoBar = FindAnyObjectByType<SustentoBar>();
        gameManager =FindAnyObjectByType<GameManager>();

        Debug.Log("Tentando carregar: " + objectId);

        intBuyied = PlayerPrefs.GetInt(objectId + "isBuyied", 0);

        Debug.Log("Valor carregado: " + intBuyied);

        if (intBuyied == 1)
        {
            isBuyied = true;
            foreach (GameObject goodChanges in empresaBoa) { goodChanges.SetActive(true); }
            foreach (GameObject badChanges in empresaRuim) { badChanges.SetActive(false); }
            canBuy.SetActive(false);
            valueText.text = "Valor: COMPRADO";

        }
        else
        {
            canBuy.SetActive(true);
            isBuyied = false;
            foreach (GameObject goodChanges in empresaBoa) { goodChanges.SetActive(false); }
            foreach (GameObject badChanges in empresaRuim) { badChanges.SetActive(true); }
            valueText.text = "Valor: " + value;
        }
    }
    private void Update()
    {
        AllIsMax();
    }
    public void OnClick()
    {
        if ((gameManager.totalPoints >= value) && (AllIsMax()) && !isBuyied)
        {
            gameManager.totalPoints -= value;
            intBuyied = 1;
            isBuyied = true;
            Debug.Log("Salvando upgrade:" + objectId);
            PlayerPrefs.SetInt(objectId + "isBuyied", intBuyied);
            sustentoBar.value += barPoints;
            foreach (GameObject goodChanges in empresaBoa) { goodChanges.SetActive(true); }
            foreach (GameObject badChanges in empresaRuim) { badChanges.SetActive(false); }
            valueText.text = "Valor: COMPRADO";
            PlayerPrefs.Save();
            foreach (Upgrades upgrades in upgrades)
            {
                upgrades.maxLevel += 5;
            }

            if (objectId == "Painel Solares")
            {
                gameManager.solarPanel = true;
                PlayerPrefs.SetInt("SolarPanel", 1);
            }

            else if (objectId == "Turbina Eolicas")
            {
                gameManager.aeolica = true;
                PlayerPrefs.SetInt("Aeolica", 1);
            }
            else if (objectId == "Usina Hidreletrica")
            {
                gameManager.hidroeEletrica = true;
                PlayerPrefs.SetInt("Hidreletrica", 1);
            }
            PlayerPrefs.Save();
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
