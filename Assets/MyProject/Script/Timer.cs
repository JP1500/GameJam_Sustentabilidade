using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{

    public static Timer Instance;
    [Header("Timer")]
    [SerializeField] public float currentTime;


    [Header("Outros componentes/objetos")]
    [SerializeField] ChangeScene changeScene;
    [SerializeField] public PlayerController playerController;

    [SerializeField] public string sceneName;

    private void Awake()
    {
        changeScene = FindAnyObjectByType<ChangeScene>();
        playerController = FindAnyObjectByType<PlayerController>();
        Instance = this;

    }

    private void Start()
    {
        currentTime = playerController.lifeTime;
    }
    void Update()
    {
        if (currentTime >= 0)
        {
            currentTime -= Time.deltaTime;

        }

        else if (currentTime <= 0)
        {
            playerController.canMove = false;
            playerController.spriteRenderer.color = Color.blue;
            changeScene.StartFade();
            Debug.Log("Carregando cena");
            Invoke("LoadScene", 1.5f);
        }
    }
}
