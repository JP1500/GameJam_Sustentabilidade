using UnityEditor.ProjectWindowCallback;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{

    public static Timer Instance;
    [Header("Timer")]
    [SerializeField] float currentTime;


    [Header("Outros componentes/objetos")]
    [SerializeField] Slider slider;
    [SerializeField] public PlayerController playerController;

    [SerializeField] public string sceneName;

    [Header("Aqui estou apenas fazendo um teste")]
    [SerializeField] public SceneManager sceneManager;

    private void Awake()
    {
        playerController = FindAnyObjectByType<PlayerController>();
        Instance = this;
    }

    private void Start()
    {
        slider.maxValue = playerController.lifeTime;
        currentTime = playerController.lifeTime;
    }
    void Update()
    {
        if (currentTime >= 0)
        {
            currentTime -= Time.deltaTime;

            slider.value = currentTime;
        }

        else if (currentTime <= 0)
        {
            playerController.canMove = false;
            playerController.spriteRenderer.color = Color.blue;
            Debug.Log("Carregando cena");
            Invoke("LoadScene", 1.5f);
        }
    }

    void LoadScene()
    {
        SceneManager.LoadScene(sceneName);
    }
}
