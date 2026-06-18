using System;
using UnityEngine;
using UnityEngine.UI;

public class SpecialUpgrade : MonoBehaviour
{
    [SerializeField] string objectId;
    [SerializeField] float timerBonus;
    [SerializeField] int pointBonus;
    [SerializeField] float speedBonus;

    [SerializeField] int value;

    [SerializeField] int intBuyied;
    [SerializeField] bool isBuyied;

    [SerializeField] Upgrades[] upgrades;

    [Header("Componentes externos")]
    [SerializeField] GameManager gameManager;
    [SerializeField] SustentoBar sustentoBar;
    [SerializeField] public GameObject empresaBoa;
    [SerializeField] public GameObject empresaRuim;

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
        }
        else
        {
            isBuyied = false;
            empresaBoa.SetActive(false);
            empresaRuim.SetActive(true);
        }
    }

    public void OnClick()
    {
        if ((gameManager.totalPoints >= value) && (AllIsMax()))
        {
            gameManager.totalPoints -= value;
            intBuyied = 1;
            isBuyied = true;
            PlayerPrefs.SetInt(objectId + "isBuyied", intBuyied);
            sustentoBar.value += 20;
            empresaBoa.SetActive(true);
            empresaRuim.SetActive(false);
            gameObject.SetActive(false);
            foreach (Upgrades upgrades in upgrades)
            {
                upgrades.maxLevel += 5;
            }
        }
    }

    bool AllIsMax()
    {
        foreach (Upgrades upgrades in upgrades)
        {
            if (!upgrades.isMax)
            {
                return false;
            }
        }
        Debug.Log("Estou podendo ser comprado");
        return true;
    }
}
