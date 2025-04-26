using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.Rendering.Universal.Internal;

public class Parallax : MonoBehaviour
{
    public Transform target;

    [Range(0, 1f)] 
    public float scale = 1f;


    public bool disableVerticalParallax;
    private Vector3 targetPrevosPosition;
    
    void Start()
    {
        if (!target)
        {
            target = Camera.main.transform;
        }
        targetPrevosPosition = target.position; 

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        var delta = target.position - targetPrevosPosition;
        if(disableVerticalParallax)
        {
            delta.y = 0f;
        }
        targetPrevosPosition = target.position;
        transform.position += delta * scale;
    }
}
