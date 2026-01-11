using System.Threading;
using UnityEngine;

public class PlayerAttackSystem : MonoBehaviour
{
    [SerializeField] private Transform attackPoint;
    [SerializeField] private AudioClip attack;
    [SerializeField] private float timeBetweenAttacks;
    [SerializeField] private float attackRadius = .5f;
    private Animator anim;
    private float timer;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if(Input.GetMouseButtonDown(0) && timer >= timeBetweenAttacks)
        {
            AudioManager.instance.PlaySFX(attack);
            anim.SetTrigger("Attack");
            timer = 0;
        }
    }

    //This method is going to be called through an animation event.
    private void AttackHits()
    {
        Collider2D[] results = Physics2D.OverlapCircleAll(attackPoint.position, attackRadius);
        foreach (Collider2D item in results)
        {
            if (item.TryGetComponent(out IDamageable damageable))
            {
                //If the enemy's damageable, it hurts them.
                damageable.TakeDamage(gameObject, 20);
            }
        }
    }

    //Automatic when you're in the scene view.
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(attackPoint.position, attackRadius);
    }
}
