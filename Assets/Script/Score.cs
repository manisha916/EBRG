//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.UI;
//using TMPro;



//public class Score : MonoBehaviour
//{
//    public TextMeshProUGUI MyScoreText;
//    private int ScoreNum;

//    void Start()
//    {
//        ScoreNum = 0;
//        MyScoreText.text = "SCORE : " + ScoreNum;
//    }

//    private void OnTriggerEnter2D(Collider2D Star)
//    {
//        if (Star.tag == "Star")
//        {
//            ScoreNum += 10;
//            Destroy(Star.gameObject);
//            MyScoreText.text = "SCORE : " +ScoreNum;

//        }

//    }

//}
