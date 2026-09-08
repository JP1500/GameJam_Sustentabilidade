using UnityEngine;


public class SpawnerLixo : MonoBehaviour
{
    [Header("Valores minimos e maximos de spawn")]
    [SerializeField] public float minX;
    [SerializeField] public float maxX;

    [SerializeField] public float minY;
    [SerializeField] public float maxY;

    [Header("Velocidade de spawn")]
    [SerializeField] float spawnSpeed;

    [Header("Componentes externos")]
    [SerializeField] GameObject lixoPrefab;
    [SerializeField] Transform[] spawnPoints;
    public Sprite[] spritesPossiveis;





    void Awake()
    {
        InvokeRepeating("Createlixo", 0f, spawnSpeed);
    }

    public void Createlixo()
    {
        Vector2 pos;

        do
        {

            pos = new Vector2(Random.Range(maxX, minX), Random.Range(maxY, minY));
        }

        while (InCamera(pos));

        GameObject lixo = Instantiate(lixoPrefab, pos, Quaternion.identity);
        Debug.Log("Spawnei fora da camera");
        int spriteIndex = Random.Range(0, spritesPossiveis.Length);

        SpriteRenderer sr = lixo.GetComponent<SpriteRenderer>();

        if (sr != null)
        {
            sr.sprite = spritesPossiveis[spriteIndex];
        }


    }

    bool InCamera(Vector2 posicao)
    {
        Vector3 tela = Camera.main.WorldToViewportPoint(posicao);

        return tela.x >= 0 && tela.x <= 1 && tela.y >= 0 && tela.y <= 1;
    }
}