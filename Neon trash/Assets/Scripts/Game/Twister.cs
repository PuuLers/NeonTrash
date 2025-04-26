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

    private void Rotate(float force)
    {
        if (reverse)
        {
            force = -force;
        }
        _rb.MoveRotation(_rb.rotation + force * 10 * Time.fixedDeltaTime);
    }

    void FixedUpdate()
    {
        if (!byTrigger)
        {
            Rotate(speed);
        }
    }

    public void ApplyTorque()
    {
        float rotationSpeed = speed * 100 * Time.fixedDeltaTime;
        _rb.AddTorque(reverse ? rotationSpeed : -rotationSpeed, ForceMode2D.Force);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision != null)
        {
            if (collision.CompareTag("Player") == true)
            {
                Rotate(speed);
            }
        }
    }

}



