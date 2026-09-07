using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{

    public static Timer Instance;
    [Header("Timer")]
    [SerializeField] public float currentTime;


    [Header("Outros componentes/objetos")]
    [SerializeField] ChangeScene changeScene;
    [SerializeField] public PlayerController playerController;

    [Header("Transição de cenas")]
    [SerializeField] public GameObject gameStart;
    [SerializeField] public GameObject transitionOut;
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
        if (!
            gameStart.activeInHierarchy)
        {
            if (currentTime >= 0)
            {
                currentTime -= Time.deltaTime;

            }

            else if (currentTime <= 0)
            {
                transitionOut.SetActive(true);
                changeScene = FindAnyObjectByType<ChangeScene>();
                playerController.canMove = false;
                playerController.spriteRenderer.color = Color.blue;
                playerController.speed = 0f;
                changeScene.StartFade();
                Debug.Log("Carregando cena");
                SceneManager.LoadScene("sceneName");
            }
        }
    }
}
