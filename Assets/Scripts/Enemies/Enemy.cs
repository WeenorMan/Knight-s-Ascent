using System.Collections;
using System.Collections.Generic;
using System.Transactions;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float patrolSpeed;
    [SerializeField] float attackCooldown;
    [SerializeField] float range;
    [SerializeField] float colliderDistance;
    [SerializeField] int damage;
    [SerializeField] private BoxCollider2D boxCollider;
    [SerializeField] private LayerMask playerLayer;
    [SerializeField] private LayerMask groundLayer;


    private float cooldownTimer = Mathf.Infinity;
    private Animator anim;
    private Health playerHealth;


    Helper helper;
    Rigidbody2D rb;
    SpriteRenderer spriteRenderer;

    void Awake()
    {
        helper = gameObject.AddComponent<Helper>();
        rb = gameObject.GetComponent<Rigidbody2D>();
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        anim = gameObject.GetComponent<Animator>();
    }

    void Update()
    {
        bool hit;
        rb.velocity = new Vector2(patrolSpeed, rb.velocity.y);


        EnemyPatrol();
        

        cooldownTimer += Time.deltaTime;


        hit = helper.ExtendedRayCollisionCheck(0, 0, Vector2.right, -2, playerLayer);
        hit = helper.ExtendedRayCollisionCheck(0, 0, Vector2.right, 2, playerLayer);

        if (PlayerInSight())
        {
            print("PlayerInSight");
            if (cooldownTimer >= attackCooldown)
            {
                
                cooldownTimer = 0;
                anim.SetTrigger("attack");
            }
        }
         
    }

    private bool PlayerInSight()
    {
        RaycastHit2D hit = Physics2D.BoxCast(boxCollider.bounds.center + transform.right * range * transform.localScale.x * colliderDistance,
            new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z),
             0, Vector2.left, 0, playerLayer);
        
        if(hit.collider != null)
        {
            playerHealth = hit.transform.GetComponent<Health>();
            
        }

        return hit.collider != null; 
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(boxCollider.bounds.center + transform.right * range * transform.localScale.x * colliderDistance,
            new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z));
    }

    private void DamagePlayer()
    {
        if (PlayerInSight())
        {
            playerHealth.TakeDamage(damage);
        }
    }

    public void EnemyPatrol()
    {
        bool lefthit = helper.ExtendedRayCollisionCheck(-0.5f, 0f, Vector2.down, 2, groundLayer );
        bool righthit = helper.ExtendedRayCollisionCheck(0.5f, 0f, Vector2.down, 2, groundLayer );
        anim.SetBool("moving", true);

        if(rb.velocity.x < 0f && !lefthit)
        {
            transform.localScale = new Vector3(3,3,3);
            patrolSpeed = -patrolSpeed;
        }
        if(rb.velocity.x > 0f && !righthit)
        {
            transform.localScale = new Vector3(-3,3,3);  
            patrolSpeed = -patrolSpeed;

        }

    }

    
}