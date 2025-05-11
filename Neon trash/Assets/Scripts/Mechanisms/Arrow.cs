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
        Cursor.visible = false;
    }
    private void SetPosition()
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = mousePosition;
    }
    private void Rotate()
    {
        if (_player != null)
        {
            transform.LookAt((new Vector2(_player.transform.position.x, _player.transform.position.y)));
        }
        else
        {
            transform.rotation = Quaternion.Euler(-90, 0, 90);
        }
    }

    void Update()
    {
        SetPosition();
        Rotate();
    }
}
