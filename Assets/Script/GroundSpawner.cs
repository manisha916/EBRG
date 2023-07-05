using UnityEngine;
public class GroundSpawner : MonoBehaviour
{
    public GameObject[] groundPrefabs;
    public Transform[] spawnPoints;

    private int currentPrefabIndex = 0; 
    private GameObject currentGround; 
    private GameObject previousGround;
    public Transform PlayerTransform;

    private void Start()
    {
        SpawnGround(spawnPoints[0].position);
    }
    private void Update()
    {
        if (Next())
        {
            Delete(previousGround);
            previousGround = currentGround;
            if (currentPrefabIndex == 4)
            {
                Debug.Log("GameOver");
            }
            else
            {
                currentPrefabIndex++;
             }
            SpawnGround(spawnPoints[currentPrefabIndex].position);
        }
    }
    private void SpawnGround(Vector3 spawnPosition)
    {
     
            GameObject randomGroundPrefav = groundPrefabs[Random.Range(0,9)];
            currentGround = Instantiate(randomGroundPrefav, spawnPosition, Quaternion.identity);
      
       
    }
    private void Delete(GameObject ground)
    {
        Destroy(ground);
    }
    private bool Next()
    {
        return PlayerTransform.position.x >= spawnPoints[currentPrefabIndex].position.x;
    }
}