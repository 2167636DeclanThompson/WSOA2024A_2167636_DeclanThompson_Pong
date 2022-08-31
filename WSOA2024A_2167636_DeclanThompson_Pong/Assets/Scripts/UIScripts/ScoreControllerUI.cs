using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreControllerUI : MonoBehaviour
{
    public Text player1ScoreDisplay;
    public Text player2ScoreDisplay;
    public Text player3ScoreDisplay;

    private int player1Score;
    private int player2Score;
    private int player3Score;

    public void PlayerScored(int playerID)
    {
        if (playerID == 1)
        {
            player1Score++;
        }
        else if (playerID == 2)
        {
            player2Score++;
        }
        else if (playerID == 3)
        {
            player3Score++;
        }
        UpdateScore();
        if (player1Score >= 10)
        {
            SceneManager.LoadScene(2);
        }
        else if (player2Score >= 10)
        {
            SceneManager.LoadScene(3);
        }
        else if (player3Score >= 10)
        {
            SceneManager.LoadScene(4);
        }
    }

    private void Start()
    {
        UpdateScore();
    }

    private void UpdateScore()
    {
        player1ScoreDisplay.text = player1Score.ToString();
        player2ScoreDisplay.text = player2Score.ToString();
        player3ScoreDisplay.text = player3Score.ToString();
    }

   
}
