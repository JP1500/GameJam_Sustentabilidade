using UnityEngine;


public class Contador : MonoBehaviour
{
    [SerializeField] SpawnerLixo spawnerLixo;

    private void Awake()
    {
        spawnerLixo = FindAnyObjectByType<SpawnerLixo>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
           Destroy(gameObject);
        }
    }
}
