using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ObstacleRotation : MonoBehaviour
{
    public float rotateSpeed;
    public float speed;
    public Transform pos1;
    public Transform pos2;
    bool turnback;
    public Score score;
    public void Start()
    {
        score = GameObject.FindObjectOfType<Score>();
    }
    void Update()
    {
        transform.Rotate(0, 0, rotateSpeed*Time.deltaTime);
        if (transform.position.y >= pos1.position.y)
        {
            turnback = true;
        }
        if (transform.position.y <= pos2.position.y)
        {
            turnback = false;
        }
        if (turnback)
        {
            transform.position = Vector2.MoveTowards(transform.position, pos2.position, speed * Time.deltaTime);
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, pos1.position, speed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            SoundManager.inst.PlaySound(SoundName.gameOver);
            collision.gameObject.SetActive(false);
            Time.timeScale = 0f;
            ScreenManager.instance.SwitchScreen(ScreenType.gameOver);
            score.GameOver();
        }
    }
}
