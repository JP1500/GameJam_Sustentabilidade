using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] GameObject player;

    private void Awake()
    {
        gameObject.transform.position = new Vector3(player.transform.position.x, player.transform.position.y, gameObject.transform.position.z);
    }

    private void Update()
    {
        gameObject.transform.position = new Vector3(player.transform.position.x, player.transform.position.y, gameObject.transform.position.z);
    }
}
