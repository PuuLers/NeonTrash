using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blade : MonoBehaviour
{
    private Twister _twister;

    private void Start()
    {
        _twister = GetComponentInParent<Twister>(); // Ищем Twister среди родителей
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && _twister != null)
        {
            Rigidbody2D playerRb = collision.gameObject.GetComponent<Rigidbody2D>();
            if (playerRb != null)
            {
                float force = playerRb.velocity.x * 10f; // Усиливаем эффект
                _twister.ApplyTorque(force);
            }
        }
    }
}
