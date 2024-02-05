using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndTV : MonoBehaviour
{
    public int id;
    private Animator animator;


    private void Start()
    {
        animator = GetComponent<Animator>();
        switch (id)
        {
            case 1:
                animator.Play("EndTV1");
                break;
            case 2:
                animator.Play("EndTV2");
                break;
            case 3:
                animator.Play("EndTV3");
                break;
            case 4:
                animator.Play("EndTV4");
                break;
            case 5:
                animator.Play("EndTV5");
                break;
        }
    }

}
