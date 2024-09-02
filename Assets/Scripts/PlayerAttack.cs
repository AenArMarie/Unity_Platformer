using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private float atkCD;
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject[] fireballs;
    private Animator animator;
    private Movement movement;
    private int num=0;
    private float cdtimer = Mathf.Infinity;
    private void Awake()
    {
        animator = GetComponent<Animator>();
        movement = GetComponent<Movement>();
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && cdtimer>atkCD && movement.canAttack())
        {
            Attack();
        }
        cdtimer+=Time.deltaTime;
    }

    private void Attack()
    {
        animator.SetTrigger("attack");
        cdtimer = 0;
        fireballs[num].transform.position = firePoint.position;
        fireballs[(num)].GetComponent<Projectile>().SetDirection(Math.Sign(transform.localScale.x));
        num = (num + 1) % 9;

    }
}
