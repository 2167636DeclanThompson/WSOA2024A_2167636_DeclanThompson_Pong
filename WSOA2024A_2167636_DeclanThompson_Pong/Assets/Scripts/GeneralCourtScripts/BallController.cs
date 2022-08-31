using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public Rigidbody2D rigidBody;
    public Vector2 initialVelocity;
    public float maxSpeed = 10f;
    private Vector3 startPosition;
    public Transform topBoundary;
    public Transform courtDivider;
    public Transform leftGoal;
    public Transform rightGoal;
    public Transform topGoal;
    public GameManager gameManager;

  
    public void resetBall(int playerID)
    {
        transform.position = startPosition;
        if (playerID == 1)
        {
            rigidBody.velocity = Vector2.left * maxSpeed;
        }
        else if (playerID == 2)
        {
            rigidBody.velocity = Vector2.right * maxSpeed;
        }
        else if (playerID == 3)
        {
            rigidBody.velocity = Vector2.up * maxSpeed;
        }
    }
 
    private void Start()
    {
        StartCoroutine(Countdown());
        rigidBody.velocity = initialVelocity.normalized * maxSpeed;
        startPosition = transform.position;
    }

    private void Update()
    {
       
        if (transform.position.y > topGoal.position.y)
        {
            gameManager.PlayerScored(3);
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (transform.position.x < courtDivider.position.x && transform.position.y < topBoundary.position.y)
        {
            gameManager.PlayerScored(1);
        }
        else if (transform.position.x > courtDivider.position.x && transform.position.y < topBoundary.position.y)
        {
            gameManager.PlayerScored(2);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        RightPaddleController rightPaddle = collision.gameObject.GetComponent<RightPaddleController>();
        if (rightPaddle != null)
        {
            Vector3 paddleVelocity = rightPaddle.getVelocity();

            if (paddleVelocity.y != 0)
            {
                float xVelocity = rigidBody.velocity.x;
                float yVelocity = rightPaddle.getVelocity().y;

                Vector2 newVelocity = new Vector2(xVelocity, yVelocity);
                newVelocity = newVelocity.normalized * maxSpeed;

                rigidBody.velocity = newVelocity;
            }
           
        }
        LeftPaddleController leftPaddle = collision.gameObject.GetComponent<LeftPaddleController>();
        if (leftPaddle != null)
        {
            Vector3 paddleVelocity = leftPaddle.getVelocity();

            if (paddleVelocity.y != 0)
            {
                float xVelocity = rigidBody.velocity.x;
                float yVelocity = leftPaddle.getVelocity().y;

                Vector2 newVelocity = new Vector2(xVelocity, yVelocity);
                newVelocity = newVelocity.normalized * maxSpeed;

                rigidBody.velocity = newVelocity;
            }

        }
        TopPaddleController topPaddle = collision.gameObject.GetComponent<TopPaddleController>();
        if (topPaddle != null)
        {
            Vector3 paddleVelocity = topPaddle.getVelocity();

            if (paddleVelocity.y != 0)
            {
                float xVelocity = topPaddle.getVelocity().y;
                float yVelocity = rigidBody.velocity.y;

                Vector2 newVelocity = new Vector2(xVelocity, yVelocity);
                newVelocity = newVelocity.normalized * maxSpeed;

                rigidBody.velocity = newVelocity;
            }

        }
    }
    
    IEnumerator Countdown()
    {
        yield return new WaitForSeconds(4);

        rigidBody.velocity = Vector2.up * maxSpeed;
    }


}
