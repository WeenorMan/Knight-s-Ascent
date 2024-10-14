using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private float attackCooldown;
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject[] fireballs;


    private Animator anim;
    private PlayerMovement PlayerMovement;
    private float cooldownTimer = Mathf.Infinity;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        PlayerMovement = GetComponent<PlayerMovement>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.X) && cooldownTimer > attackCooldown && PlayerMovement.CanAttack())
        {
            Attack();

            cooldownTimer += Time.deltaTime;
        }
        else if (Input.GetKeyDown(KeyCode.Z) && cooldownTimer > attackCooldown && PlayerMovement.CanAttack())
        {
            Cast();

            cooldownTimer += Time.deltaTime;
        }
    }

    private void Attack()
    {
        anim.SetTrigger("attack");
        cooldownTimer = 0;
    }

    private void Cast()
    {
        anim.SetTrigger("castattack");
        cooldownTimer = 0;

        fireballs[FindFireball()].transform.position = firePoint.position;
        fireballs[FindFireball()].GetComponent<Fireball>().SetDirection(Mathf.Sign(transform.localScale.x));
    }

    private int FindFireball()
    {
        for (int i = 0; i < fireballs.Length; i++)
        {
            if (!fireballs[i].activeInHierarchy)
            {
                return i;
            }
        }
        return 0;
    }
}
