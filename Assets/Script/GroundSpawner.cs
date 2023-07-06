using UnityEngine;
public class GroundSpawner : MonoBehaviour
{
    public static GroundSpawner instance;
    public GameObject[] groundPrefabs;
    public Transform[] spawnPoints;

    private int currentPrefabIndex = 0; 
    private GameObject currentGround; 
    private GameObject previousGround;
    public Transform PlayerTransform;

    public GameObject parent;

   
    public Vector3 playerStartPos;
    public Vector3 prefabPos;
    public Vector3 camPos;


    private void Awake()
    {
        instance = this;
    }
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
            if (currentPrefabIndex == 10)
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
     
            GameObject randomGroundPrefav = groundPrefabs[Random.Range(0,3)];
            currentGround = Instantiate(randomGroundPrefav, spawnPosition, Quaternion.identity);
            currentGround.transform.SetParent(parent.transform);
      
       
    }
    private void Delete(GameObject ground)
    {
        Destroy(ground);
    }
    private bool Next()
    {
        return PlayerTransform.position.x >= spawnPoints[currentPrefabIndex].position.x;
    }
    public void DestroyChildPrefav()
    {
        foreach (Transform child in parent.transform)
        {
            Destroy(child.gameObject);
        }
    }
    public void GameStart()
    {
        SpawnGround(spawnPoints[0].position);

    }
}