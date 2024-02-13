using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class Figure : MonoBehaviour
{
    public float dtime = 10;

    void Start()
    {
        Move();
        StartCoroutine(IDel());
    }

    private void Move()
    {
        StartCoroutine(IMove());
    }

    IEnumerator IMove()
    {
        while (true)
        {
            transform.position += new Vector3(0, -0.5f, 0);
            yield return new WaitForSeconds(Random.Range(0.2f, 0.4f));
        }
    }

    IEnumerator IDel()
    {
        yield return new WaitForSeconds(20);
        Destroy(gameObject);
    }

}
