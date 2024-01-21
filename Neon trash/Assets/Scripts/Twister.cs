using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Twister : MonoBehaviour
{
    public float speed;
    public bool reverse;

    private void Rotate()
    {
        if (reverse)
        {
            transform.Rotate(0, 0, speed);
        }
        else
        {
            transform.Rotate(0, 0, -speed);
        }
    }


    void FixedUpdate()
    {
        Rotate();
    }
}
