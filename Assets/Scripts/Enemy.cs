using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject player;
    Helper helper;
    Rigidbody2D rb;
    float px, ex;
    SpriteRenderer spriteRenderer;
    void Start()
    {
        helper = gameObject.AddComponent<Helper>();
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        LookingAtPlayer();
        helper.DoRayCollisionCheck();
    }

    public void LookingAtPlayer()
    {
        px = player.transform.position.x;
        ex = transform.position.x;

        if (ex < px)
        {
            transform.localScale = Vector3.one;
        }
        else
        {
            transform.localScale = new Vector3(-1, 1, 1);

        }
    }
}