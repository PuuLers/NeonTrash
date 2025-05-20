using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star : MonoBehaviour
{
    public Level level;
    ParticleSystem particle;
    Animator animator;
    private void Start()
    {
        particle = GetComponentInParent<ParticleSystem>();
        animator = GetComponent<Animator>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player")) return;
        animator.SetBool("die", true);
        Level level = collision.gameObject.GetComponent<Level>();
        level.StarNumberAdd();
        
    }

    public void ParticleSystem()
    {
        particle.Play();
    }
}
