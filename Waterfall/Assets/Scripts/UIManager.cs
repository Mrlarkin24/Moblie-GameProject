using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    CatScript playerController;
    public HighScore ScoreChecker;

    GameObject[] pauseObjects;
    GameObject[] highObjects;
    GameObject[] endObjects;

    public int pubScore;
    public Text Firetext, Timetext, Mousetext, Powertext, Scoretext, HighName;

    bool gameOn, gameOver;
    static int level = 0;
    float timeLeft = 60.0f, score = 0;

    // Use this for initialization
    void Start()
    {
        gameOn = false;
        Time.timeScale = 1;

        pauseObjects = GameObject.FindGameObjectsWithTag("ShowOnPause");
        highObjects = GameObject.FindGameObjectsWithTag("ShowOnHigh");
        endObjects = GameObject.FindGameObjectsWithTag("ShowOnEnd");
        

        hidePaused();
        hideHigh();
        hideEnd();

        //Checks to make sure one of the main scenes are loaded
        if (Application.loadedLevelName == "MainScene" || Application.loadedLevelName == "MainScene2" || Application.loadedLevelName == "MainScene3")
        {
            playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<CatScript>();
            gameOn = true;
            gameOver = true;
        }
    }

    // Update is called once per frame
    void Update()
    {

        //uses the p button to pause and unpause the game
        if (Input.GetKeyDown(KeyCode.P) && gameOver)
        {
            if (Time.timeScale == 1)
            {
                Time.timeScale = 0;
                showPaused();
            }
            else if (Time.timeScale == 0)
            {
                Time.timeScale = 1;
                hidePaused();
            }
        }

        //Gets rid of menu errors
        if (gameOn)
        {

            timeLeft -= Time.deltaTime;

            //Displays counters/timers on UI
            Firetext.text = ": " + (5 - playerController.fireCount).ToString();
            Mousetext.text = ": " + playerController.mouseCount.ToString();
            Powertext.text = "Invincible: " + ((int)playerController.timeMouse).ToString();
            Timetext.text = ((int)timeLeft).ToString();
            Scoretext.text = "Score: " + ((int)score).ToString();

            //Check if time has run out so it can change levels
            if (timeLeft < 0)
            {
                if (Application.loadedLevelName == "MainScene")
                {
                    LoadLevel("MainScene2");
                    level = 1;
                }
                else if (Application.loadedLevelName == "MainScene2")
                {
                    LoadLevel("MainScene3");
                    level = 2;
                }
            }

            //Checks if player has died
            if (playerController.alive == false)
            {
                gameOver = false;
                Score();
                showEnd();
                
                // Checks if players score is a new highscore 
                if (ScoreChecker.Checker(pubScore))
                {
                    showHigh();
                }
            }
        }
    }

    //Reloads the Level
    public void Reload()
    {
        Application.LoadLevel("MainScene");
    }

    //controls the pausing of the scene
    public void pauseControl()
    {
        if (Time.timeScale == 1)
        {
            Time.timeScale = 0;
            showPaused();
        }
        else if (Time.timeScale == 0)
        {
            Time.timeScale = 1;
            hidePaused();
        }
    }

    //shows objects with ShowOnPause tag
    public void showPaused()
    {
        foreach (GameObject g in pauseObjects)
        {
            g.SetActive(true);
        }
    }

    //hides objects with ShowOnPause tag
    public void hidePaused()
    {
        foreach (GameObject g in pauseObjects)
        {
            g.SetActive(false);
        }
    }

    //shows objects with ShowOnEnd tag
    public void showEnd()
    {
        foreach (GameObject g in endObjects)
        {
            g.SetActive(true);
        }
    }

    //hides objects with ShowOnEnd tag
    public void hideEnd()
    {
        foreach (GameObject g in endObjects)
        {
            g.SetActive(false);
        }
    }

    //shows objects with ShowOnHigh tag
    public void showHigh()
    {
        foreach (GameObject g in highObjects)
        {
            g.SetActive(true);
        }
    }

    //hides objects with ShowOnHigh tag
    public void hideHigh()
    {
        foreach (GameObject g in highObjects)
        {
            g.SetActive(false);
        }
    }

    //loads inputted level
    public void LoadLevel(string level)
    {
        Application.LoadLevel(level);
    }

    public void Score()
    {
        score = 7 * (61 - timeLeft) + (level * 60);
        pubScore = ((int)score);
    }

    //Sends New Highscore and name when called
    public void EnterName()
    {
       //Checks if entered name is empty
       if (HighName.text != string.Empty)
        {
            //Debug.Log(HighName.text);
            ScoreChecker.StoreHighscore(pubScore, HighName.text);
        }
    }
}
