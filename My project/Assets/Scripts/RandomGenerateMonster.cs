using UnityEngine;
using UnityEngine.Pool;

public class RandomGenerateMonster : MonoBehaviour
{
    [SerializeField] private int maxEnemies;
    [SerializeField] private GameObject[] enemiesType;
    [SerializeField] private LayerMask groundLayer;

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
            bool isGround = false;
            int count = 0;

            int randomType = 0;
            Vector3 randomSpawnPosition = Vector3.zero;

            while (!isGround && count < 30)
            {
                randomType = Random.Range(0, enemiesType.Length);
                randomSpawnPosition = new Vector3(Random.Range(minPosX, maxPosX), spawnZone.bounds.max.y, Random.Range(minPosZ, maxPosZ));
                Ray ray = new Ray(randomSpawnPosition, Vector3.down);
                Debug.DrawRay(randomSpawnPosition, Vector3.down, Color.red);

                if (Physics.Raycast(ray, out RaycastHit hit, 200, groundLayer))
                {
                    randomSpawnPosition = hit.point;
                    isGround = true;
                }

                count++;
            }
                if (isGround == true)
                {
                    Instantiate(enemiesType[randomType], randomSpawnPosition, enemiesType[randomType].transform.rotation);
                }
        }
    }
}
