using UnityEngine;
using UnityEngine.InputSystem;

public class RemoveJoystick : MonoBehaviour
{
    [SerializeField] GameManager gameManager;
    [SerializeField] GameObject joyStick;


    private void Awake()
    {
        gameManager = FindAnyObjectByType<GameManager>();
    }

    private void Start()
    {
        if (gameManager.inPC)
        {
            joyStick.SetActive(false);
        }
        else if (!gameManager.inPC)
        {
            joyStick.SetActive(true);
        }
    }
}
