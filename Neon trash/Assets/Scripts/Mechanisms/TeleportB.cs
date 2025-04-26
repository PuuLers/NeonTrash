using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TeleportB : MonoBehaviour
{
    private GameObject player;

    private void FixedUpdate()
    {
        Rotate();
    }

    private void Rotate()
    {
        transform.Rotate(0, 0, -1);
    }


    private void Start()
    {
        player = GameObject.Find("Scavenger");
        player.transform.position = transform.position;
    }
}
