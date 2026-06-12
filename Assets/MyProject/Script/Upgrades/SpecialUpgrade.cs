using System;
using UnityEngine;

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

    private void Awake()
    {
        upgrades = FindObjectsByType<Upgrades>(FindObjectsSortMode.None);

        gameManager =FindAnyObjectByType<GameManager>();
        intBuyied = PlayerPrefs.GetInt(objectId + "isBuyied", intBuyied);

        if (intBuyied == 1)
        {
            isBuyied = true;
        }
        else
        {
            isBuyied = false;
        }
    }

    private void Update()
    {
        if (AllIsMax())
        {
            Debug.Log("Estou podendo ser comprado");
        }
    }

    public void OnClick()
    {
        if ((gameManager.totalPoints >= value) && (AllIsMax()))
        {
            intBuyied = 1;
            isBuyied = true;
            PlayerPrefs.SetInt(objectId + "isBuyied", intBuyied);
            gameObject.SetActive(false);
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
        return true;
    }
}
