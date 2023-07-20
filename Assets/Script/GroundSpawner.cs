//using UnityEngine;
//public class GroundSpawner : MonoBehaviour
//{
//    public static GroundSpawner instance;
//    public GameObject[] groundPrefabs;
//    public Transform[] spawnPoints;

//    private int currentPrefabIndex = 0; 
//    private GameObject currentGround; 
//    private GameObject previousGround;
//    public Transform PlayerTransform;
//    public Transform cameraTransform;

//    public GameObject parent;

//    private PlayerController playerController;
//    private CameraMovement cameraMovement;
//    private void Awake()
//    {
//        instance = this;
//    }
//    private void Start()
//    {
//        parent = new GameObject("GroundParent");
//        playerController = PlayerTransform.GetComponent<PlayerController>();
//        cameraMovement = cameraTransform.GetComponent<CameraMovement>();

//    }

//    private void Update()
//    {
//        if (Next())
//        {
//            Delete(previousGround);
//            previousGround = currentGround;
//            currentPrefabIndex++;
//            SpawnGround(spawnPoints[currentPrefabIndex].position);
//        }

//    }






//    private void SpawnGround(Vector3 spawnPosition)
//    {

//        GameObject randomGroundPrefav = groundPrefabs[Random.Range(0, groundPrefabs.Length - 1)];
//        currentGround = Instantiate(randomGroundPrefav, spawnPosition, Quaternion.identity);
//        currentGround.transform.SetParent(parent.transform);


//    }


//    private void Delete(GameObject ground)
//    {
//        Destroy(ground);
//    }
//    private bool Next()
//    {
//        return PlayerTransform.position.x >= spawnPoints[currentPrefabIndex].position.x;
//    }
//    public void DestroyChildPrefav()
//    {
//        foreach (Transform child in parent.transform)
//        {
//            Destroy(child.gameObject);
//        }
//    }
//    public void StartGame()
//    {
//        Debug.Log("gameStart");
//        playerController.playerTrailRenderer.enabled = false;
//        currentPrefabIndex = 0;
//        SpawnGround(spawnPoints[0].position);
//        playerController.ResetPlayer();
//        cameraMovement.ResetCamera();


//    }
//    public void StartGame1()
//    {
//        Debug.Log("gameStart1");
//        playerController.playerTrailRenderer.enabled = false;
//        currentPrefabIndex = 0;
//        playerController.ResetPlayer();
//        cameraMovement.ResetCamera();


//    }
//}
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

    private float lastSpawn = 0f;
    private float gap = 40f;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        parent = new GameObject("GroundParent");
        playerController = PlayerTransform.GetComponent<PlayerController>();
        cameraMovement = cameraTransform.GetComponent<CameraMovement>();
        lastSpawn = spawnPoints[1].position.x;
    }

    private void Update()
    {
        if (Next())
        {
            Delete(previousGround);
            previousGround = currentGround;
            currentPrefabIndex++;
            SpawnGround(new Vector3(lastSpawn + gap, 0f, 0f));
            lastSpawn += gap;
        }
    }

    private void SpawnGround(Vector3 spawnPosition)
    {
        GameObject randomGroundPrefab = groundPrefabs[Random.Range(0, groundPrefabs.Length)];
        currentGround = Instantiate(randomGroundPrefab, spawnPosition, Quaternion.identity);
        currentGround.transform.SetParent(parent.transform);
    }

    private void Delete(GameObject ground)
    {
        Destroy(ground);
    }

    private bool Next()
    {
        return PlayerTransform.position.x >= lastSpawn - gap * 0.1f;
       
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
       lastSpawn = spawnPoints[0].position.x;
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
