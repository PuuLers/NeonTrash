using System.Collections;
using System.Collections.Generic;
using UnityEditor.UI;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class Rocket : MonoBehaviour
{
    private Rigidbody2D _rigidbody;
    public float speed;
    private GameObject _player;
    public bool _active = true;
    private void Move()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
        Follow();
    }

    private void Follow()
    {
        Vector3 diference = _player.transform.position - transform.position;
        float rotateZ = Mathf.Atan2(diference.y, diference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotateZ);
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


    void FixedUpdate()
    {
        if (_active)
        {
            Move();
        }
        Invoke("Deactivate", 5);
    }
}
