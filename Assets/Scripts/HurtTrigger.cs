
using UnityEngine;

public class HurtTrigger : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Bread") || other.gameObject.CompareTag("Duck"))
        {
            Health health = other.gameObject.GetComponentInParent<Health>(); 
            health.TakeDamage();
            Rigidbody2D rb = other.gameObject.GetComponentInParent<Rigidbody2D>();
            rb.AddForce(transform.up * 500);
        }
    }
}
