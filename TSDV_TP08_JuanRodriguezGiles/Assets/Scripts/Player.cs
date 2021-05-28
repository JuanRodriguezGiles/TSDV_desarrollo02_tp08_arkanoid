using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Player : MonoBehaviour
{
    private int hp = 3;
    private float speed = 5;
    void Awake()
    {
        Ball.onBallTouchBottom += removeHp;
    }
    void Update()
    {
        if (Input.GetAxisRaw("Horizontal") == 1.0f)
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        if (Input.GetAxisRaw("Horizontal") == -1.0f)
            transform.Translate(Vector3.left * speed * Time.deltaTime);
    }
    void removeHp()
    {
        hp--;
    }
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.GetComponent<Ball>())
        {
            float hitRange = (col.transform.position.x - transform.position.x) / GetComponent<BoxCollider>().bounds.size.x;
            Vector2 direction = new Vector2(hitRange, 1).normalized;
            col.rigidbody.velocity = direction * col.gameObject.GetComponent<Ball>().speed;
        }
    }
}
