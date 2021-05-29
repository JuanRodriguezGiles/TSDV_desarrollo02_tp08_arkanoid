using UnityEngine;
public class BottomCollider : MonoBehaviour
{
    void OnTriggerEnter(Collider col)
    {
        if (col.GetComponent<Ball>())
        {
            col.GetComponent<Ball>().OnBallTouchBottom();
        }
    }
}
