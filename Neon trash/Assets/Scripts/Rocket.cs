using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.UI;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;
using static UnityEngine.GraphicsBuffer;

public class Rocket : MonoBehaviour
{
    private Rigidbody2D _rigidbody;
    public float speed;
    public float smoothSpeed;
    private GameObject _player;
    private bool _active = false;
    private void Move()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
        Follow();
    }

    private void Gravity()
    {
        if (_active)
        {
            _rigidbody.gravityScale = 0;
        }
        else
        {
            _rigidbody.gravityScale = 1;
        }
    }
    private void Follow()
    {
        Vector3 targetPosition = new Vector3(_player.transform.position.x, _player.transform.position.y, transform.position.z);
        Vector3 direction = targetPosition - transform.position; // Направление к целевой позиции
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg; // Вычисляем угол в радианах и конвертируем в градусы
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward); // Поворачиваем объект в заданное направление
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * smoothSpeed); // Применяем плавное вращение
    }

    private void Deactivate()
    {
        _active = false;
        _rigidbody.gravityScale = 1;
    }

    void Start()
    {
        _player = GameObject.Find("Scavenger");
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            _active = true;
        }
    }

    void FixedUpdate()
    {
        if (_active)
        {
            Move();
            Invoke("Deactivate", 5);
        }
        Gravity();
    }
}
