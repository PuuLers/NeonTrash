using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class Scavenger2 : MonoBehaviour
{
    public GameObject nozzleL;
    public GameObject nozzleR;
    private Rigidbody2D _rigidbody;
    public float normalizationRotation;
    private Animator nozzleRAnimator;
    private Animator nozzleLAnimator;
    public float impulse;
    private bool _isGrounded;
    public Rigidbody2D nozzleLRigidbody;
    public Rigidbody2D nozzleRRigidbody;



    void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        nozzleLAnimator = nozzleL.GetComponent<Animator>();
        nozzleRAnimator = nozzleR.GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        //FollowNozzleL();
        //FollowNozzleR();
        //NormalizationRotation(normalizationRotation);
        Move();
        Animate();
        //CheckGround();
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
            nozzleLRigidbody.AddForce(new Vector3(-impulse * Mathf.Cos(angelL), -impulse * Mathf.Sin(angelL), 0), ForceMode2D.Impulse);
        }
        if (Input.GetMouseButton(1))
        {
            float angelR = FollowNozzleR() * Mathf.Deg2Rad;
            nozzleRRigidbody.AddForce(new Vector3(-impulse * Mathf.Cos(angelR), -impulse * Mathf.Sin(angelR), 0), ForceMode2D.Impulse);
        }
    }
    private void Restart()
    {
        if (Input.GetButtonDown("Jump"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }



    private void Animate()
    {
        if(Input.GetMouseButton(1))
        {
            nozzleRAnimator.speed = 2f;
        }
        else
        {
            nozzleRAnimator.speed = 0.5f;
        }
        if (Input.GetMouseButton(0))
        {
            nozzleLAnimator.speed = 2f;
        }
        else
        {
            nozzleLAnimator.speed = 0.5f;
        }

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
        if (!_isGrounded)
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
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

}
