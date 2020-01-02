using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighScore : MonoBehaviour
{
    UIManager ScoreChecker;

    int score, hScore1, hScore2, hScore3, hScore4, hScore5;

    // Start is called before the first frame update
    void Start()
    {
        score = ScoreChecker.pubScore;
    }

    // Update is called once per frame
    void Update()
    {
        if (score > hScore5)
        {
            StoreHighscore(score);
        }
        
    }

    void StoreHighscore(int newHighscore)
    {
        int oldHighscore = PlayerPrefs.GetInt("highscore", 0);

        if (newHighscore > oldHighscore)
        {
            PlayerPrefs.SetInt("highscore", newHighscore);
            
        }
        PlayerPrefs.Save();
    }
}
