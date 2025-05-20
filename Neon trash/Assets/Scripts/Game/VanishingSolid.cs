using UnityEngine;
public class VanishingSolid : MonoBehaviour
{
    public GameObject blade;
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Destroy(gameObject); 
            blade.SetActive(true);
        }
    }
}
