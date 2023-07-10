
using UnityEngine;

public class BaseController : MonoBehaviour
{
    private bool isPlayerOnGround = false;

   
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isPlayerOnGround = true;
            Debug.Log("enter");
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isPlayerOnGround = false;
            gameObject.SetActive(false);
            Debug.Log("exit");
        }
    }

}



//using UnityEngine;
//using TMPro;
//using System.IO;

//public class Score : MonoBehaviour
//{
//    public TextMeshProUGUI MyScoreText;
//    public TextMeshProUGUI gameOverScoreText;
//    public TextMeshProUGUI highScoreText; // Add a reference to the high score text

//    private int ScoreNum;
//    private int HighScoreNum;
//    private string scoreFilePath;

//    private void Awake()
//    {
//        scoreFilePath = Application.persistentDataPath + "/score1.json";
//        Debug.Log(scoreFilePath);
//    }

//    void Start()
//    {
//        LoadScore();
//        UpdateScoreText();
//    }

//    private void OnCollisionEnter2D(Collision2D collision)
//    {
//        if (collision.gameObject.CompareTag("Star"))
//        {
//            ScoreNum += 10;
//            Destroy(collision.gameObject);
//            UpdateScoreText();

//            if (ScoreNum > HighScoreNum)
//            {
//                HighScoreNum = ScoreNum;
//                UpdateHighScoreText();
//            }
//        }
//    }

//    public void GameOver()
//    {
//        gameOverScoreText.text = "Score: " + ScoreNum;
//        SaveScore();
//    }

//    private void UpdateScoreText()
//    {
//        MyScoreText.text = "Score: " + ScoreNum;
//    }

//    private void UpdateHighScoreText()
//    {
//        highScoreText.text = "High Score: " + HighScoreNum;
//    }

//    private void SaveScore()
//    {
//        ScoreData scoreData = new ScoreData { ScoreNum = ScoreNum, HighScoreNum = HighScoreNum };
//        string jsonData = JsonUtility.ToJson(scoreData);
//        File.WriteAllText(scoreFilePath, jsonData);
//    }

//    private void LoadScore()
//    {
//        if (File.Exists(scoreFilePath))
//        {
//            string jsonData = File.ReadAllText(scoreFilePath);
//            ScoreData scoreData = JsonUtility.FromJson<ScoreData>(jsonData);
//            HighScoreNum = scoreData.HighScoreNum;
//        }

//    }
//}

//[System.Serializable]
//public class ScoreData
//{
//    public int ScoreNum;
//    public int HighScoreNum;
//}