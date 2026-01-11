using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour, IDamageable
{
    [SerializeField] private float movementForce;
    [SerializeField] private float jumpForce;
    [SerializeField] private float health = 3f;
    [SerializeField] private AudioClip jump;
    [SerializeField] private AudioClip hurt;
    private bool grounded;
    private float hInput;
    private Rigidbody2D rb;
    private Animator anim;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void Start()
    {
        transform.position = GameManager.instance.SavedPosition;
        transform.eulerAngles = GameManager.instance.SavedRotation;
    }

    // Update is called once per frame
    void Update()
    {
        hInput = Input.GetAxisRaw("Horizontal");
        anim.SetFloat("xSpeed", Mathf.Abs(hInput));
        anim.SetFloat("ySpeed", rb.linearVelocity.y);
        FaceMovement();
        grounded = Physics2D.CircleCast(transform.position, 0.5f, Vector2.down, 1f);
        if (grounded) 
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                AudioManager.instance.PlaySFX(jump);
                rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            }
        }
    }
    private void FaceMovement()
    {
        if (hInput < 0 && transform.eulerAngles.y == 0)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
        else if (hInput > 0)
        {
            transform.eulerAngles = Vector3.zero;
        }
    }
    void FixedUpdate()
    {
        rb.AddForce(new Vector2 (hInput, 0) * movementForce, ForceMode2D.Force);
    }

    public void TakeDamage(GameObject dealer, float damage)
    {
        Vector3 knockbackDirection = transform.position - dealer.transform.position;
        knockbackDirection.y = 0;
        StartCoroutine(Knockback(knockbackDirection));
        AudioManager.instance.PlaySFX(hurt);
        health -= damage;
        Debug.Log("My new health is " +  health);
        if (health <= 0)
        {
            Destroy(gameObject);
            SceneManager.LoadScene("GameOver");
        }
    }

    private IEnumerator Knockback(Vector3 knockbackDirection)
    {
        rb.AddForce(knockbackDirection.normalized * 5f, ForceMode2D.Impulse);
        yield return new WaitForSeconds(0.5f);
        rb.linearVelocity = Vector3.zero;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Ouch!");
            TakeDamage(other.gameObject, 1f);
        }
    }
}
