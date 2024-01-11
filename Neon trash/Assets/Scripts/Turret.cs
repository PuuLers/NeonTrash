using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class Turret : MonoBehaviour
{
    public GameObject rocketRed;
    public GameObject rocketWhite;
    public bool follow;
    public bool red;
    private Rigidbody2D _rigidbody;
    private GameObject _player;
    private Transform point;
    void Start()
    {
        _player = GameObject.Find("Scavenger");
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Spawn()
    {

    }

    private void Follow()
    {
        if (follow)
        {
            Vector3 diference = _player.transform.position - transform.position;
            float rotateZ = Mathf.Atan2(diference.y, diference.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, 0f, rotateZ);
        }
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        Follow();
    }
}

