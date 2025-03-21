using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
using static UnityEditor.Experimental.GraphView.GraphView;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class Scavenger : MonoBehaviour
{

    
    //public float normalizationRotation;
    public float smoothSpeed;
    public float impulse;
    private bool _isGrounded;

    private Rigidbody2D _rigidbody;

    public GameObject nozzleL;
    public GameObject nozzleR;

    private Animator nozzleRAnimator;
    private Animator nozzleLAnimator;
    private Animator _animator;

    void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        nozzleLAnimator = nozzleL.GetComponent<Animator>();
        nozzleRAnimator = nozzleR.GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        FollowNozzleL();
        FollowNozzleR();
        //NormalizationRotation(normalizationRotation);
        Move();
        Animate();
        CheckGround();
        Follow();
    }

    private void Update()
    {
        Restart();
    }

    private void Move()
    {
        if (Input.GetMouseButton(0))
        {
            float angelL = FollowNozzleL() * Mathf.Deg2Rad;
            _rigidbody.AddForce(new Vector3(-impulse * Mathf.Cos(angelL), -impulse * Mathf.Sin(angelL), 0), ForceMode2D.Impulse);
            float angelR = FollowNozzleR() * Mathf.Deg2Rad;
            _rigidbody.AddForce(new Vector3(-impulse * Mathf.Cos(angelR), -impulse * Mathf.Sin(angelR), 0), ForceMode2D.Impulse);
        }

    }
   private void Restart()
    {
        if (Input.GetButtonDown("Jump"))
        {
            SceneManager.LoadScene(1);
        }
    }

    private void Follow()
    {
        if (Input.GetMouseButton(1))
        {
            _rigidbody.angularVelocity = 0;
            Vector3 targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3 direction = targetPosition - transform.position; // Íàïðàâëåíèå ê öåëåâîé ïîçèöèè
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg; // Âû÷èñëÿåì óãîë â ðàäèàíàõ è êîíâåðòèðóåì â ãðàäóñû
            Quaternion rotation = Quaternion.AngleAxis(angle + 90, Vector3.forward); // Ïîâîðà÷èâàåì îáúåêò â çàäàííîå íàïðàâëåíèå
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * smoothSpeed); // Ïðèìåíÿåì ïëàâíîå âðàùåíèå
        }
    }


    private void Animate()
    {
        bool _state = Input.GetMouseButton(0) || Input.GetMouseButton(1);
        nozzleRAnimator.speed = _state ? 2f : 0.5f;
        nozzleLAnimator.speed = _state ? 2f : 0.5f;
    }

    private float FollowNozzleL()
    {
        Vector3 diference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float rotateZ = Mathf.Atan2(diference.y, diference.x) * Mathf.Rad2Deg;
        nozzleL.transform.rotation = Quaternion.Euler(0f, 0f, rotateZ);

        return rotateZ;
    }
    private float FollowNozzleR()
    {
        Vector3 diference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float rotateZ = Mathf.Atan2(diference.y, diference.x) * Mathf.Rad2Deg;
        nozzleR.transform.rotation = Quaternion.Euler(0f, 0f, rotateZ);

        return rotateZ;
    }



    private void NormalizationRotation(float norm)
    {
        if(!_isGrounded)
        {
            Debug.Log(123);
            if (transform.rotation.z > 0)
            {
                transform.Rotate(new Vector3(0, 0, -norm));
            }

            if (transform.rotation.z < 0)
            {
                transform.Rotate(new Vector3(0, 0, norm));
            }
        }
    }

    private void CheckGround()
    {
        Collider2D[] col = Physics2D.OverlapCircleAll(transform.position, 0.3f);
        _isGrounded = col.Length > 1;
       
    }


    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Red")
        {
            SceneManager.LoadScene(1);
        }
        else if (collision.gameObject.CompareTag("Twister"))
        {
            ApplyForceToTwister(collision);
        }
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Twister"))
        {
            ApplyForceToTwister(collision);
        }
    }

    private void ApplyForceToTwister(Collision2D collision)
    {
        Twister twister = collision.gameObject.GetComponent<Twister>();
        if (twister != null)
        {
            // Определяем направление движения игрока и применяем силу к твистеру
            float torqueForce = _rigidbody.velocity.x * impulse;
            twister.ApplyTorque(torqueForce);
        }
    }


}
