using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class Scavenger : MonoBehaviour
{
    public GameObject nozzleL;
    public GameObject nozzleR;
    private Rigidbody2D _rigidbody;
    public float normalizationRotation;
    private Animator _animator;



    void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        FollowNozzleL();
        FollowNozzleR();
        NormalizationRotation(normalizationRotation);
        Move();
        Animate();
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
            _rigidbody.AddForce(new Vector3(-1f * Mathf.Cos(angelL), -1f * Mathf.Sin(angelL), 0), ForceMode2D.Impulse);
            float angelR = FollowNozzleR() * Mathf.Deg2Rad;
            _rigidbody.AddForce(new Vector3(-1f * Mathf.Cos(angelR), -1f * Mathf.Sin(angelR), 0), ForceMode2D.Impulse);
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
        if (Input.GetMouseButton(0))
        {
            _animator.speed = 2;
        }
        else
        {
            _animator.speed = 0.5f;
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
        if (transform.rotation.z > 0)
        {
            transform.Rotate(new Vector3(0, 0, -norm));
        }

        if (transform.rotation.z < 0)
        {
            transform.Rotate(new Vector3(0, 0, norm));
        }

    }

            


    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Red")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

}
