using UnityEngine;

public class GroundSpawner : MonoBehaviour
{
    public GameObject[] groundPrefabs;
    public Transform[] spawnPoints;

    private int currentPrefabIndex = 0; 
    private GameObject currentGround; 
    public Transform PlayerTransform;

    private void Start()
    {
        SpawnGround(spawnPoints[0].position);
    }

    private void Update()
    {
        if (NextSpawnPoint())
        {  
            currentPrefabIndex++;
            if (currentPrefabIndex >= groundPrefabs.Length)
            {
                currentPrefabIndex = 0;
            }
            SpawnGround(spawnPoints[currentPrefabIndex].position);
        }
    }

    private void SpawnGround(Vector3 spawnPosition)
    {
        currentGround = Instantiate(groundPrefabs[currentPrefabIndex], spawnPosition, Quaternion.identity);
    }

    private bool NextSpawnPoint()
    {
        return PlayerTransform.position.x >= spawnPoints[currentPrefabIndex].position.x;
    }
}