using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftPaddleController : MonoBehaviour
{
    public KeyCode RightButton, LeftButton;
    public float speed = 5f;
    public float offsetBoundary = 0.5f;
    public Transform CourtDivider, TopBoundary, LeftBoundary, BottomBoundary;
    private Vector3 startPosition;
    private Vector3 velocity;
    public Vector3 getVelocity()
    {
        return velocity;
    }

    private void Start()
    {
        startPosition = transform.position;
    }

    private void Update()
    {
        if (Input.GetKey(RightButton))
        {
            float xPosition = transform.position.x + speed * Time.deltaTime;
            float yPosition = transform.position.y - speed * Time.deltaTime;

            xPosition = Mathf.Clamp(xPosition, LeftBoundary.position.x, CourtDivider.position.x - offsetBoundary);
            yPosition = Mathf.Clamp(yPosition, BottomBoundary.position.y, TopBoundary.position.y);

            transform.position = new Vector3(xPosition, yPosition, transform.position.z);

            velocity = Vector3.up * speed;
        }
        else if (Input.GetKey(LeftButton))
        {
            float xPosition = transform.position.x - speed * Time.deltaTime;
            float yPosition = transform.position.y + speed * Time.deltaTime;

            xPosition = Mathf.Clamp(xPosition, LeftBoundary.position.x, CourtDivider.position.x - offsetBoundary);
            yPosition = Mathf.Clamp(yPosition, BottomBoundary.position.y, TopBoundary.position.y);

            transform.position = new Vector3(xPosition, yPosition, transform.position.z);

            velocity = Vector3.down * speed;
        }

    }

}
