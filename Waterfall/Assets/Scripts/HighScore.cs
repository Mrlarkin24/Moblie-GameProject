using UnityEngine;
using UnityEngine.UI;

public class HighScore : MonoBehaviour
{
    UIManager ScoreChecker;

    public Text hScore1, hScore2, hScore3, hScore4, hScore5, nScore1, nScore2, nScore3, nScore4, nScore5, highName;

    // Start is called before the first frame update
    void Start()
    {
        hScore1.text = PlayerPrefs.GetInt("HighScore1").ToString();
        hScore2.text = PlayerPrefs.GetInt("HighScore2").ToString();
        hScore3.text = PlayerPrefs.GetInt("HighScore3").ToString();
        hScore4.text = PlayerPrefs.GetInt("HighScore4").ToString();
        hScore5.text = PlayerPrefs.GetInt("HighScore5").ToString();

        nScore1.text = PlayerPrefs.GetString("HighName1", "Place Holder");
        nScore2.text = PlayerPrefs.GetString("HighName2", "Place Holder");
        nScore3.text = PlayerPrefs.GetString("HighName3", "Place Holder");
        nScore4.text = PlayerPrefs.GetString("HighName4", "Place Holder");
        nScore5.text = PlayerPrefs.GetString("HighName5", "Place Holder");
    }

    // Update is called once per frame
    public bool Checker(int score)
    {
        if (score > PlayerPrefs.GetInt("HighScore5"))
        {
            return true;
           //StoreHighscore(score);
        }

        return false;
    }

    public void StoreHighscore(int newHighscore, string newName)
    {
        int oldHighscore1, oldHighscore2;
        string oldName1, oldName2;

        if (newHighscore > PlayerPrefs.GetInt("HighScore1")) //Beats HighScore #1
        {
            //Changing HighScore #1
            oldName1 = PlayerPrefs.GetString("HighName1", "Place Holder");
            oldHighscore1 = PlayerPrefs.GetInt("HighScore1");
            PlayerPrefs.SetString("HighName1", newName);
            PlayerPrefs.SetInt("HighScore1", newHighscore);

            //Changing HighScore #2
            oldName2 = PlayerPrefs.GetString("HighName2", "Place Holder");
            oldHighscore2 = PlayerPrefs.GetInt("HighScore2");
            PlayerPrefs.SetString("HighName2", oldName1);
            PlayerPrefs.SetInt("HighScore2", oldHighscore1);

            //Changing HighScore #3
            oldName1 = PlayerPrefs.GetString("HighName3", "Place Holder");
            oldHighscore1 = PlayerPrefs.GetInt("HighScore3");
            PlayerPrefs.SetString("HighName3", oldName2);
            PlayerPrefs.SetInt("HighScore3", oldHighscore2);

            //Changing HighScore #4
            oldName2 = PlayerPrefs.GetString("HighName4", "Place Holder");
            oldHighscore2 = PlayerPrefs.GetInt("HighScore4");
            PlayerPrefs.SetString("HighName4", oldName1);
            PlayerPrefs.SetInt("HighScore4", oldHighscore1);

            //Changing HighScore #5
            PlayerPrefs.SetString("HighName5", oldName2);
            PlayerPrefs.SetInt("HighScore5", oldHighscore2);
        }
        else if (newHighscore > PlayerPrefs.GetInt("HighScore2")) //Beats HighScore #2
        {
            //Changing HighScore #2
            oldName2 = PlayerPrefs.GetString("HighName2", "Place Holder");
            oldHighscore2 = PlayerPrefs.GetInt("HighScore2");
            PlayerPrefs.SetString("HighName2", newName);
            PlayerPrefs.SetInt("HighScore2", newHighscore);

            //Changing HighScore #3
            oldName1 = PlayerPrefs.GetString("HighName3", "Place Holder");
            oldHighscore1 = PlayerPrefs.GetInt("HighScore3");
            PlayerPrefs.SetString("HighName3", oldName2);
            PlayerPrefs.SetInt("HighScore3", oldHighscore2);

            //Changing HighScore #4
            oldName2 = PlayerPrefs.GetString("HighName4", "Place Holder");
            oldHighscore2 = PlayerPrefs.GetInt("HighScore4");
            PlayerPrefs.SetString("HighName4", oldName1);
            PlayerPrefs.SetInt("HighScore4", oldHighscore1);

            //Changing HighScore #5
            PlayerPrefs.SetString("HighName5", oldName2);
            PlayerPrefs.SetInt("HighScore5", oldHighscore2);
        }
        else if (newHighscore > PlayerPrefs.GetInt("HighScore3")) //Beats HighScore #3
        {
            //Changing HighScore #3
            oldName1 = PlayerPrefs.GetString("HighName3", "Place Holder");
            oldHighscore1 = PlayerPrefs.GetInt("HighScore3");
            PlayerPrefs.SetString("HighName3", newName);
            PlayerPrefs.SetInt("HighScore3", newHighscore);

            //Changing HighScore #4
            oldName2 = PlayerPrefs.GetString("HighName4", "Place Holder");
            oldHighscore2 = PlayerPrefs.GetInt("HighScore4");
            PlayerPrefs.SetString("HighName4", oldName1);
            PlayerPrefs.SetInt("HighScore4", oldHighscore1);

            //Changing HighScore #5
            PlayerPrefs.SetString("HighName5", oldName2);
            PlayerPrefs.SetInt("HighScore5", oldHighscore2);
        }
        else if (newHighscore > PlayerPrefs.GetInt("HighScore4")) //Beats HighScore #4
        {
            //Changing HighScore #4
            oldName2 = PlayerPrefs.GetString("HighName4", "Place Holder");
            oldHighscore2 = PlayerPrefs.GetInt("HighScore4");
            PlayerPrefs.SetString("HighName4", newName);
            PlayerPrefs.SetInt("HighScore4", newHighscore);

            //Changing HighScore #5
            PlayerPrefs.SetString("HighName5", oldName2);
            PlayerPrefs.SetInt("HighScore5", oldHighscore2);
        }
        else //Beats HighScore #5
        {
            //Changing HighScore #5
            PlayerPrefs.SetString("HighName5", newName);
            PlayerPrefs.SetInt("HighScore5", newHighscore);
        }

        PlayerPrefs.Save();
    }
}
