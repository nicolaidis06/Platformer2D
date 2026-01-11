using UnityEngine;

public class Cannonball : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Vector3 initDirection;
    private Vector3 currentDirection;
    private float timer = 0;
    public float travelTime = 3;
    private void Start()
    {
        currentDirection = initDirection;
    }
    void Update()
    {
        timer += Time.deltaTime;
        transform.Translate(currentDirection * speed * Time.deltaTime);
        Destroy(gameObject, travelTime);
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Wall"))
        {
            Destroy(this);
        }
    }
}
