using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public GameObject player;
    public float fall = -20f;

    private bool isGameOver = false;
    public Score score;
    public void Start()
    {
        score = GameObject.FindObjectOfType<Score>();
    }
    void Update()
    {
        if (!isGameOver && player.transform.position.y < fall)
        {
         
            ScreenManager.instance.SwitchScreen(ScreenType.gameOver);
            Time.timeScale = 0f;
            score.GameOver();
         
        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("Obstacle"))
        {
            SoundManager.inst.PlaySound(SoundName.gameOver);
            gameObject.SetActive(false);
            Time.timeScale = 0f;
            ScreenManager.instance.SwitchScreen(ScreenType.gameOver);
            score.GameOver();
        }
    }
}

