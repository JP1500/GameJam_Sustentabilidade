using UnityEngine;

public class EmpresaMudando : MonoBehaviour
{
    [SerializeField] GameManager gameManager;

    [Header ("Mudanças positivas")]
    [SerializeField] GameObject[] goodSolarPanelChanges;
    [SerializeField] GameObject[] goodHidreletricaChanges;
    [SerializeField] GameObject[] goodAeolicaChanges;

    [Header ("Mudanças negativas")]
    [SerializeField] GameObject[] badSolarPanelChanges;
    [SerializeField] GameObject[] badHidreletricaChanges;
    [SerializeField] GameObject[] badAeolicaChanges;

    private void Awake()
    {
        gameManager = FindAnyObjectByType<GameManager>();

        if (gameManager.solarPanel)
        {
            foreach (GameObject goodChanges in goodSolarPanelChanges)
            {
                goodChanges.SetActive(true);
            }
            foreach (GameObject badChanges in badSolarPanelChanges)
            {
                badChanges.SetActive(false);
            }
        }
        if (gameManager.hidroeEletrica)
        {
            foreach (GameObject goodChanges in goodHidreletricaChanges)
            {
                goodChanges.SetActive(true);
            }
            foreach (GameObject badChanges in badHidreletricaChanges)
            {
                badChanges.SetActive(false);
            }
        }
        if (gameManager.aeolica)
        { 
            foreach (GameObject goodChanges in goodAeolicaChanges)
            {
                goodChanges.SetActive(true);
            }
            foreach (GameObject badChanges in badAeolicaChanges)
            {
                badChanges.SetActive(false);
            }
                
        }
    }

    void Update()
    {
        
    }
}
