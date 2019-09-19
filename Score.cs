using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    Text scoreText;
    public int score;
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        scoreText = GetComponent<Text>();
    }
    public void SetScore(int addScore)
    {
        score = score + addScore;
        scoreText.text = score.ToString();
    }
}
