using System;
using UnityEngine;
public class Brick : MonoBehaviour
{
    public static event Action onBrickDestroyed;
    public void OnBrickDestroyed()
    {
        onBrickDestroyed?.Invoke();
    }
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.GetComponent<Ball>())
        {
            Destroy(this.gameObject);
            OnBrickDestroyed();
        }
    }
}