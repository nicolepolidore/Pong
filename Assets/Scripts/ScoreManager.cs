using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class ScoreManager : MonoBehaviour
{
     public int scorePlayerLeft = 0;
     public int scorePlayerRight = 0;

    public Text scoreLeft;
    public Text scoreRight;
    public Text winnerText;

    public Button exitButton;


    bool isPaused = false;

    public AudioSource scoreSound;

     void Start()
    {
       
            exitButton.gameObject.SetActive(false);
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        AddScoreLeft();
        AddScoreRight();
    }

    public void AddScoreLeft()
    {
        //increasing left / red's score
        scorePlayerLeft++;
        scoreLeft.text = scorePlayerLeft.ToString();
        scoreSound.Play();

        if(scorePlayerLeft == 5)
        {

            winnerText.text = "RED WINS!" ;
            Debug.Log ("won");
            exitButton.gameObject.SetActive(true);
            pausedGame();

        }
        else
        {
            exitButton.gameObject.SetActive(false);
        }

    }

    public void AddScoreRight()
    {
        //increasing right / blue's score
        scorePlayerRight++;
        scoreRight.text = scorePlayerRight.ToString();
        scoreSound.Play();



        if (scorePlayerRight == 5)
        {
            winnerText.text = "BLUE WINS!";
            Debug.Log( "won");
            exitButton.gameObject.SetActive(true);
            pausedGame();


        }
        else
        {
            exitButton.gameObject.SetActive(false);
        }

    }
    public void pausedGame()
    {
        //pausing game when a player wins
        if (isPaused)
        {
            Time.timeScale = 1;
            isPaused = false;
        }
        else
        {
            Time.timeScale = 0;
            isPaused = true;
        }
       

    }

   



}
