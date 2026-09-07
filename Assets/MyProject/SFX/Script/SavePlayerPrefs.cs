using UnityEngine;

public class SavePlayerPrefs : MonoBehaviour
{
    [SerializeField] GameObject panelUpgrade;
    [SerializeField] GameObject panelEspecialUpgrade;

    private void Awake()
    {
        panelUpgrade.SetActive(true);
        panelEspecialUpgrade.SetActive(true);
    }
    void Start()
    {
        panelEspecialUpgrade.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
