using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class Lazer : MonoBehaviour
{
    [Range(0f, 50f)]
    public float length;
    [Range(0f, 10f)]
    public float lifeTime;
    public bool alwaysActive;
    public GameObject lazer;
    private float timer = 0f;
    private bool isActive = false;
    private Animator animator;
    public float delay;
    private void Stabilization()
    {
        float coefficient = lazer.transform.localScale.x / 2;
        lazer.transform.localPosition = new Vector3(coefficient, lazer.transform.localPosition.y, lazer.transform.localPosition.z);
        lazer.transform.localScale = new Vector3(length, lazer.transform.localScale.y, lazer.transform.localScale.z);
    }

    private void Activate()
    {
        
        lazer.SetActive(true);
    }
    private void Deactivate()
    {
        
        lazer.SetActive(false);
    }

    private void blinking()
    {
        timer += Time.fixedDeltaTime;
        if (timer >= lifeTime)
        {
            if (isActive)
            {
                Activate();
                isActive = false;
            }
            else
            {
                Deactivate();
                isActive = true;
            }
            timer = 0;
        }

    }
    void Start()
    {
        animator = GetComponent<Animator>();
        timer -= delay;
    }



    void FixedUpdate()
    {
        blinking();
        Stabilization();
        if (!alwaysActive)
        {
            blinking();
        }
        else
        {
            Activate();
        }
    }
}
