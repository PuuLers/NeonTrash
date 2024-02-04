using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    public Transform destination;
    private Collider2D collision;
    //private Rigidbody2D rb;
    public GameObject sprite;
    public bool thisB;

    private void FixedUpdate()
    {
        Rotate();
    }

    private void Rotate()
    {
        if (!thisB)
        {
            sprite.transform.Rotate(0, 0, 1);
        }
        else
        {
            sprite.transform.Rotate(0, 0, -1);
        }
    }




    private void OnTriggerStay2D(Collider2D collision)
    {
        if (!thisB)
        {
            this.collision = collision;
            //rb = collision.GetComponent<Rigidbody2D>();
            if (Vector2.Distance(collision.transform.position, transform.position) > 0.3f)
            {
                StartCoroutine(IPortal());
            }
        }
    }

    IEnumerator IPortal()
    {

        //rb.simulated = false;
        //yield return new WaitForSeconds(0.5f);
        collision.transform.position = Vector2.MoveTowards(collision.transform.position, transform.position, 3 * Time.deltaTime);
        yield return new WaitForSeconds(0.25f);
        collision.transform.position = destination.transform.position;
        //rb.simulated = true;
    }
}
