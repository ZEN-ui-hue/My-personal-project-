using UnityEngine;

public class RandomGenerateMonster : MonoBehaviour
{
    [SerializeField] private int maxEnemies;
    [SerializeField] private GameObject[] enemiesType;

    private BoxCollider spawnZone;

    void Start()
    {
        spawnZone = GetComponent<BoxCollider>();

        float minPosX = spawnZone.bounds.min.x;
        float maxPosX = spawnZone.bounds.max.x;

        float minPosZ = spawnZone.bounds.min.z;
        float maxPosZ = spawnZone.bounds.max.z;


        for (int i = 0; i < maxEnemies; i++)
        {
            int randomType = Random.Range(0, enemiesType.Length);
            Vector3 randomSpawnPosition = new Vector3(Random.Range(minPosX, maxPosX), spawnZone.bounds.min.y,Random.Range(minPosZ, maxPosZ));
            Instantiate(enemiesType[randomType], randomSpawnPosition, enemiesType[randomType].transform.rotation);
        }
    }
}
