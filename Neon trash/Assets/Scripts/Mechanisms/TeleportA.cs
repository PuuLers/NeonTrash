using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TeleportA : MonoBehaviour
{
    private Collider2D collision;

    private void FixedUpdate()
    {
        Rotate();
    }

    private void Rotate()
    {
        transform.Rotate(0, 0, 1);
    }




    private void OnTriggerStay2D(Collider2D collision)
    {
        this.collision = collision;
        if (Vector2.Distance(collision.transform.position, transform.position) > 0.3f && collision.CompareTag("Player") == true)
        {
            StartCoroutine(IPortal());
        }
    }

    IEnumerator IPortal()
    {
        //rb.simulated = false;
        //yield return new WaitForSeconds(0.5f);
        collision.transform.position = Vector2.MoveTowards(collision.transform.position, transform.position, 3 * Time.deltaTime);
        yield return new WaitForSeconds(0.25f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        //rb.simulated = true;
    }
}
