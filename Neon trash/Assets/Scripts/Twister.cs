using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Twister : MonoBehaviour
{
    [Range(0, 100f)] public float speed;
    public bool reverse;
    public bool byTrigger;
    private Rigidbody2D _rb;
    private float _externalTorque;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Rotate()
    {
        float rotationSpeed = speed * 10 * Time.fixedDeltaTime;
        _rb.MoveRotation(_rb.rotation + (reverse ? rotationSpeed : -rotationSpeed));
    }

    void FixedUpdate()
    {
        if (!byTrigger)
        {
            Rotate();
        }

        if (_externalTorque != 0)
        {
            _rb.MoveRotation(_rb.rotation + _externalTorque * Time.fixedDeltaTime);
            _externalTorque = 0; // Обнуляем после применения
        }
    }

    public void ApplyTorque(float force)
    {
        _externalTorque = force; // Применяем внешний импульс
    }
}

