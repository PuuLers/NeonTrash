using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using static UnityEngine.GraphicsBuffer;

public class Arrow : MonoBehaviour
{

    private GameObject _player;
    
    void Awake()
    {
        _player = GameObject.FindGameObjectWithTag("Player");

    }
    private void SetPosition()
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = mousePosition;
    }
    private void Rotate()
    {
        transform.LookAt((new Vector2(_player.transform.position.x, _player.transform.position.y)));
    }

    void Update()
    {
        SetPosition();
        Rotate();
    }
}
