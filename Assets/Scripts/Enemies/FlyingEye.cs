using System.Collections;
using UnityEngine;

public class FlyingEye : MonoBehaviour, IDamageable
{
    [SerializeField] private float health = 100;
    private Rigidbody2D rb;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void TakeDamage(GameObject dealer, float damage)
    {
        Vector3 knockbackDirection = transform.position - dealer.transform.position;
        knockbackDirection.y = 0;
        StartCoroutine(Knockback(knockbackDirection));
        health -= damage;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
    private IEnumerator Knockback(Vector3 knockbackDirection)
    {
        rb.bodyType = RigidbodyType2D.Dynamic;
        rb.AddForce(knockbackDirection.normalized * 5f, ForceMode2D.Impulse);
        yield return new WaitForSeconds(0.5f); 
        rb.linearVelocity = Vector3.zero;
        rb.bodyType = RigidbodyType2D.Kinematic;
    }
}
