using System;
using UnityEngine;
public class Ball : MonoBehaviour
{
    public Transform PaddleTransform;
    private bool moving = false;
    public float speed = 10.0f;
    public static event Action onBallTouchBottom;
    public void OnBallTouchBottom()
    {
        onBallTouchBottom?.Invoke();
    }
    public static event Action onBallTouchPaddle;
    public void OnBallTouchPaddle()
    {
        onBallTouchPaddle?.Invoke();
    }
    void Awake()
    {
        onBallTouchBottom += ResetBall;
        onBallTouchPaddle += BounceOffPaddle;
    }
    void Update()
    {
        if (!moving)
        {
            FollowPaddle();
            if (Input.GetKeyDown(KeyCode.Space))
            {
                LaunchBall();
            }
        }
    }
    void FollowPaddle()
    {
        transform.position = new Vector3(PaddleTransform.position.x, PaddleTransform.position.y + 1, 0);
    }
    void LaunchBall()
    {
        GetComponent<Rigidbody>().velocity = Vector3.up * speed;
        moving = true;
    }
    void ResetBall()
    {
        moving = false;
        transform.position = new Vector3(PaddleTransform.position.x, PaddleTransform.position.y + 1, 0);
        GetComponent<Rigidbody>().velocity = Vector3.zero;
    }
    void BounceOffPaddle()
    {
        float hitRange = (transform.position.x - PaddleTransform.position.x) / PaddleTransform.GetComponent<BoxCollider>().bounds.size.x;
        Vector2 direction = new Vector2(hitRange, 1).normalized;
        GetComponent<Rigidbody>().velocity = direction * speed;
        speed++;
    }
}