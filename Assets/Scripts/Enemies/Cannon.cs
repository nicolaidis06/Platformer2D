using System.Collections;
using UnityEngine;

public class Cannon : MonoBehaviour, IDamageable
{
    [SerializeField] private float health = 100;
    private Rigidbody2D rb;

    public Transform cannonballSpawnPoint;
    public GameObject cannonballPrefab;
    [SerializeField] public float cannonballDelay;
    [SerializeField] public AudioClip cannonFire;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        StartCoroutine(Sequence());
    }

    IEnumerator Sequence()
    {
        /*AudioManager.instance.PlaySFX(cannonFire);*/
        Debug.Log("Fire!");
        var bullet = Instantiate(cannonballPrefab, cannonballSpawnPoint.position, cannonballSpawnPoint.rotation);
        yield return new WaitForSeconds(cannonballDelay);
        StartCoroutine(Sequence());
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
