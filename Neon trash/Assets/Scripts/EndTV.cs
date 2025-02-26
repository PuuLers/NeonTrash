using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndTV : MonoBehaviour
{
    public int id;
    private Animator animator;

    private static readonly Dictionary<int, string> animatorSet = new Dictionary<int, string>()
    {
        { 1, "EndTV1" },
        { 2, "EndTV2" },
        { 3, "EndTV3" },
        { 4, "EndTV4" },
        { 5, "EndTV5" },
    };

    // Или так:
    private void Start() => GetComponent<Animator>().Play(animatorSet[id]);

    // Или вот так еще можно
    // Тогда animatorSet не нужен
    // Не это не на столько гибко, ибо могут быть названия с друим форматом
    //private void Start() => GetComponent<Animator>().Play($"EndTV{id}");

    //private void Start()
    //{
    //    animator = GetComponent<Animator>();
    //    switch (id)
    //    {
    //        case 1:
    //            animator.Play("EndTV1");
    //            break;
    //        case 2:
    //            animator.Play("EndTV2");
    //            break;
    //        case 3:
    //            animator.Play("EndTV3");
    //            break;
    //        case 4:
    //            animator.Play("EndTV4");
    //            break;
    //        case 5:
    //            animator.Play("EndTV5");
    //            break;
    //    }
    //}

}
