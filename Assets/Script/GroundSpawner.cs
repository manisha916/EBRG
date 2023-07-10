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
    public Transform cameraTransform;

    public GameObject parent;

    private PlayerController playerController;
    private CameraMovement cameraMovement;
    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        parent = new GameObject("GroundParent");
        // SpawnGround(spawnPoints[0].position);
        playerController = PlayerTransform.GetComponent<PlayerController>();
        cameraMovement = cameraTransform.GetComponent<CameraMovement>();

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
     
            GameObject randomGroundPrefav = groundPrefabs[Random.Range(0,4)];
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
    public void StartGame()
    {
        Debug.Log("gameStart");
        playerController.playerTrailRenderer.enabled = false;
        currentPrefabIndex = 0;
        SpawnGround(spawnPoints[0].position);
        playerController.ResetPlayer();
        cameraMovement.ResetCamera();
       

    }
    public void StartGame1()
    {
        Debug.Log("gameStart1");
        playerController.playerTrailRenderer.enabled = false;
        currentPrefabIndex = 0;
        playerController.ResetPlayer();
        cameraMovement.ResetCamera();
     

    }
}