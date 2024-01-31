using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Twister : MonoBehaviour
{
    [Range(0, 100f)] public float speed;
    public bool reverse;
    public bool byTrigger;
    private Rigidbody2D _rb;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }
    private void Rotate()
    {
        if (reverse)
        {

            _rb.MoveRotation(_rb.rotation + speed * 10 * Time.fixedDeltaTime);
        }
        else
        {

            _rb.MoveRotation(_rb.rotation + -speed * 10 * Time.fixedDeltaTime);
        }
    }


    void FixedUpdate()
    {
        if (!byTrigger)
        {
            Rotate();

        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && byTrigger)
        {
            Rotate();
        }
    }
}
