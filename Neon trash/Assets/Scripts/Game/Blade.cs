using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blade : MonoBehaviour
{
    private GameObject blade;
	public bool Appear = false;

    void Start()
    {
        blade = gameObject;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Scavenger player;
        if (collision.gameObject.CompareTag("Player"))
        {
            player = collision.gameObject.GetComponent<Scavenger>();
            player.TakeDamage(1);
            blade.SetActive(Appear);
        }
        
        
		
    }
}
