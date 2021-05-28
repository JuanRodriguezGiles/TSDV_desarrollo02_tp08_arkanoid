using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Brick : MonoBehaviour
{
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.GetComponent<Ball>())
        {
            Destroy(this.gameObject);
        }
    }
}