using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    private Animator feder;


    private void Start()
    {
        feder = GameObject.Find("Fede").GetComponent<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Heart") == true)
        {
            feder.Play("FedeEnd");
        }
    }
}
