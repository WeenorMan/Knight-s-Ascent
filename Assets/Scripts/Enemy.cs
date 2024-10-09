using System.Collections;
using System.Collections.Generic;
using System.Transactions;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float patrolSpeed;
    
    Helper helper;
    Rigidbody2D rb;
    SpriteRenderer spriteRenderer;
    LayerMask groundLayer;

    void Start()
    {
        helper = gameObject.AddComponent<Helper>();
        rb = gameObject.GetComponent<Rigidbody2D>();
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        EnemyPatrol();
    }

    public void EnemyPatrol()
    {
        bool leftHit = helper.ExtendedRayCollisionCheck(-0.5f, 0f);
        bool rightHit = helper.ExtendedRayCollisionCheck(0.5f, 0f);


        if (rb.velocity.x < 0.1f && !leftHit)
        {
            transform.localScale = new Vector3(1, 1, 1);
            rb.velocity = new Vector2(-3f, rb.velocity.y);

        }
        if (rb.velocity.x > 0.1f && !rightHit)
        {
            transform.localScale = new Vector3(-1, 1, 1);
            rb.velocity = new Vector2(3f, rb.velocity.y);

        }
        else 
        {
            transform.localScale = new Vector3(-1,1,1);
            rb.velocity = new Vector2(-3f, rb.velocity.y);
        }
    
        

    }
}