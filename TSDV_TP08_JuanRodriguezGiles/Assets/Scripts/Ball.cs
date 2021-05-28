using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public Transform PaddleTransform;
    private bool moving = false;
    public float speed = 100.0f;
    public static event Action onBallTouchBottom;
    public void OnBallTouchBottom()
    {
        onBallTouchBottom?.Invoke();
    }

    void Awake()
    {
        onBallTouchBottom += ResetBall;
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
        GetComponent<Rigidbody>().velocity=Vector3.zero;
    }
}
