using System;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class SustentoBar : MonoBehaviour
{
    [SerializeField] Slider slideBar;
    [SerializeField] TextMeshProUGUI valueText;
    [SerializeField] GameObject victoryButton;

    [SerializeField] public float value;

    private void Awake()
    {
        victoryButton.SetActive(false);
        slideBar = GetComponent<Slider>();
        valueText = valueText = GetComponentInChildren<TextMeshProUGUI>();
        value = PlayerPrefs.GetFloat("sustentoBar", value);

        slideBar.value = value;
        valueText.text = value.ToString() + "%";
    }

    private void Update()
    {
        valueText.text = value.ToString() + "%";
        slideBar.value = value;
        PlayerPrefs.SetFloat("sustentoBar", value);

        if (slideBar.value >= 100)
        {
            victoryButton.SetActive(true);
        }
    }
}
