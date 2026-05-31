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
 
   void Awake()
   {
    InvokeRepeating("Createlixo", 0f, spawnSpeed);
   }

   void Createlixo()
   {
        int _index = Random.Range(0, spawnPoints.Length);
        Vector2 pos = spawnPoints[_index].position;
        pos.x += Random.Range(maxX, minX);
        pos.y += Random.Range(maxY, minY);

        GameObject lixo = Instantiate(lixoPrefab, pos,spawnPoints[_index].rotation);
   }

}
