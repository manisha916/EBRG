

using UnityEngine;
using TMPro;
using System.IO;

public class Score : MonoBehaviour
{
    public TextMeshProUGUI MyScoreText;
    public TextMeshProUGUI gameOverScoreText;
    public TextMeshProUGUI highScoreText; 

    private int ScoreNum;
    private int HighScoreNum;
    private string scoreFilePath;

    private void Awake()
    {
        scoreFilePath = Application.persistentDataPath + "/Score.json";
        Debug.Log(scoreFilePath);
    }

    void Start()
    {
        LoadScore();
        UpdateHighScoreText();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Star"))
        {
            SoundManager.inst.PlaySound(SoundName.s3);
            ScoreNum += 10;
            Destroy(collision.gameObject);
            UpdateScoreText();

            if (ScoreNum > HighScoreNum)
            {
                HighScoreNum = ScoreNum;
                UpdateHighScoreText();
            }
        }
    }

    public void GameOver()
    {
        gameOverScoreText.text = "Score: " + ScoreNum;
        SaveScore();
    }

    private void UpdateScoreText()
    {
        MyScoreText.text = ScoreNum.ToString();

    }

    private void UpdateHighScoreText()
    {   
        highScoreText.text = "HIGH SCORE: " +"<b>"+ HighScoreNum+"</b>";
    }

    private void SaveScore()
    {
        ScoreData scoreData = new ScoreData { ScoreNum = ScoreNum, HighScoreNum = HighScoreNum };
        string jsonData = JsonUtility.ToJson(scoreData);
        File.WriteAllText(scoreFilePath, jsonData);
    }

    private void LoadScore()
    {
        if (File.Exists(scoreFilePath))
        {
            string jsonData = File.ReadAllText(scoreFilePath);
            ScoreData scoreData = JsonUtility.FromJson<ScoreData>(jsonData);
            HighScoreNum = scoreData.HighScoreNum;
        }
    }

    public void ResetScore()
    {
        ScoreNum = 0; 
        UpdateScoreText();
    }
}

[System.Serializable]
public class ScoreData
{
    public int ScoreNum;
    public int HighScoreNum;
}
