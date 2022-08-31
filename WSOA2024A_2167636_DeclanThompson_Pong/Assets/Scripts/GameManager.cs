using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public KeyCode Escape;
    public ScoreControllerUI scoreControllerUI;
    public BallController ballController;
    public TimerUI timerUI;
    public LeftPaddleController leftPaddle;
    public RightPaddleController rightPaddle;
    public TopPaddleController topPaddle;

    public int WinScore = 5;
    public float maxTime;
    private float currentTime;

    private void Start()
    {
        currentTime = maxTime;
    }
    public void Update()
    {
        if (currentTime > 0)
        {
            currentTime -= Time.deltaTime;
            timerUI.UpdateTime(currentTime);
            if (currentTime <= 0)
            {
                StartGame();

            }
        }
        if (Input.GetKey(Escape))
        {
            Application.Quit();
        }
    }
    



    private void StartGame()
    {
        timerUI.gameObject.SetActive(false);
        
    }
    public void PlayerScored(int playerID)
    {
        scoreControllerUI.PlayerScored(playerID);

        ballController.resetBall(playerID);
    }

   


}

 
