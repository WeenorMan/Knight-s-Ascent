using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float speed;
    public GameObject player;
    Helper helper;
    Rigidbody2D rb;
    float px, ex;
    SpriteRenderer spriteRenderer;
    float enemyDirection;
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
        bool hit;
        hit = helper.ExtendedRayCollisionCheck(-0.5f, 0);
        hit = helper.ExtendedRayCollisionCheck(0.5f, 0);

        if (rb.velocity.x < 0f && !hit)
        {
            helper.FlipObject(true);
            rb.velocity = new Vector2(-3f, rb.velocity.y);

        }
        if (rb.velocity.x > 0f && !hit)
        {
            helper.FlipObject(false);
            rb.velocity = new Vector2(3f, rb.velocity.y);

        }

    }
}