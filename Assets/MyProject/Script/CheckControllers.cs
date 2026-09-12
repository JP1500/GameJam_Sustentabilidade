using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class CheckControllers : MonoBehaviour
{
    [SerializeField] GameManager gameManager;
    [SerializeField] Slider slider;
    [SerializeField] Image background;


    private void Awake()
    {
        gameManager = FindAnyObjectByType<GameManager>();
        slider = GetComponent<Slider>();
    }

    private void Update()
    {
        gameManager = FindAnyObjectByType<GameManager>();
        ChangePlataform();
    }
    private void ChangePlataform()
    {
        if (slider.value == 1)
        {
            gameManager.inPC = true;
            background.color = Color.white;
        }
        else if (slider.value == 0)
        {
            gameManager.inPC = false;
            background.color = Color.darkGray;
        }
    }
}
