using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Tetris : MonoBehaviour
{
    public GameObject[] figure;
    public float time;
    
    //private float[] angles = { 0, 90, 180, 270 };
    private readonly float[] _angles = { 0, 90, 180, 270 };
    public bool zeroPosition;
    GameObject fig;

    private void Start()
    {
        StartCoroutine(ISpawner());
    }


    IEnumerator ISpawner()
    {
        while (true)
        {
            yield return new WaitForSeconds(time);
            Vector3 pos = new Vector3(0, 0, _angles[Random.Range(0, _angles.Length)]);
            
            fig = Instantiate(figure[Random.Range(0, figure.Length)]);
            fig.transform.Rotate(pos);
            fig.transform.position = zeroPosition ? transform.position :
                new Vector2(transform.position.x + Random.Range(-3f, 3f), transform.position.y + Random.Range(-3f, 3f));

            //if (zeroPosition)
            //{
            //    fig.transform.position = transform.position;
            //}
            //else
            //{
            //    fig.transform.position = new Vector2(transform.position.x + Random.Range(-3f, 3f), transform.position.y + Random.Range(-3f, 3f));
            //}
        }
    }
}
