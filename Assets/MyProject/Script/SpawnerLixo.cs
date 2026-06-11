using UnityEngine;


public class SpawnerLixo : MonoBehaviour
{
    [SerializeField] float minX;
    [SerializeField] float maxX;

    [SerializeField] float minY;
    [SerializeField] float maxY;

    [SerializeField] GameObject lixoPrefab;
    [SerializeField] Transform[] spawnPoints;
    [SerializeField] float spawnSpeed;

    public Sprite[] spritesPossiveis;



    void Awake()
    {
        InvokeRepeating("Createlixo", 0f, spawnSpeed);
    }

    public void Createlixo()
    {
        int _index = Random.Range(0, spawnPoints.Length);
        Vector2 pos = spawnPoints[_index].position;
        pos.x += Random.Range(maxX, minX);
        pos.y += Random.Range(maxY, minY);

        GameObject lixo = Instantiate(lixoPrefab, pos, spawnPoints[_index].rotation);

        int spriteIndex = Random.Range(0, spritesPossiveis.Length);

        SpriteRenderer sr = lixo.GetComponent<SpriteRenderer>();

        if (sr != null)
        {
            sr.sprite = spritesPossiveis[spriteIndex];
        }


    }
}