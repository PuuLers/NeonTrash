using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.UI;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;
using static UnityEngine.GraphicsBuffer;

public class Rocket : MonoBehaviour
{
    public ParticleSystem ps;
    private Rigidbody2D _rigidbody;
    public float actionTime;
    public float speed;
    public float smoothSpeed;
    private GameObject _player;
    private bool _active = false;



    private void Move()
    {


        Vector2 vector = new Vector2(_player.transform.position.x, _player.transform.position.y);
        //_rigidbody.AddForce(vector * speed * 10 * Time.fixedDeltaTime, ForceMode2D.Force);
        transform.Translate(Vector2.right * speed * Time.deltaTime);
        //transform.position += Vector3.right * speed * Time.deltaTime;

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
        Vector3 direction = targetPosition - transform.position; // ����������� � ������� �������
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg; // ��������� ���� � �������� � ������������ � �������
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward); // ������������ ������ � �������� �����������
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * smoothSpeed); // ��������� ������� ��������
    }

    private void Deactivate()
    {
        _active = false;
        _rigidbody.gravityScale = 1;

    }

    void Start()
    {

        _player = GameObject.Find("Scavenger");
        ps = GetComponent<ParticleSystem>();
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
            Invoke("Deactivate", actionTime);
        }
        Gravity();
    }
}
