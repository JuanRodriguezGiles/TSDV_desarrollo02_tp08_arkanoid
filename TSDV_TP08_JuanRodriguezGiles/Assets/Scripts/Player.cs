using UnityEngine;
public class Player : MonoBehaviour
{
    private float speed = 5;
    void Update()
    {
        if (Input.GetAxisRaw("Horizontal") == 1.0f)
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        if (Input.GetAxisRaw("Horizontal") == -1.0f)
            transform.Translate(Vector3.left * speed * Time.deltaTime);
    }
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.GetComponent<Ball>())
        {
            col.gameObject.GetComponent<Ball>().OnBallTouchPaddle();
        }
    }
}
