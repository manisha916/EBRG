using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public GameObject player;
    public float fall = -20f;

    private bool isGameOver = false;

 
    void Update()
    {
        if (!isGameOver && player.transform.position.y < fall)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        }
    }


}

