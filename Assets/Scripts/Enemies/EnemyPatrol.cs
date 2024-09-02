using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    [Header ("Patrol Points")]
    [SerializeField] private Transform leftEdge;
    [SerializeField] private Transform rightEdge;

    [Header("Enemy")]
    [SerializeField] private Transform enemy;

    [Header("Movement parameters")]
    [SerializeField] private float speed;
    [SerializeField] private float idleDuration;
    [SerializeField] private float idletimer;
    private Vector3 initScale;
    private bool movingleft;

    [Header("Enemy Animator")]
    [SerializeField]  private Animator animator;
    private void Awake()
    {
        initScale = enemy.localScale;
    }
    private void OnDisable()
    {
        animator.SetBool("walking", false);
    }

    private void Update()
    {
        if (movingleft)
        {
            if(enemy.position.x>=leftEdge.position.x)
                MoveInDirection(-1);
            else
            {
                DirectionChange();
            }

        }
        else
        {
            if (enemy.position.x <= rightEdge.position.x)
                MoveInDirection(1);
            else
            {
                DirectionChange();
            }
        }
    }

    private void MoveInDirection(int _direction)
    {
        idletimer = 0;
        animator.SetBool("walking", true);
        enemy.localScale = new Vector3(Math.Abs(initScale.x)*_direction, initScale.y, initScale.z);
        enemy.position = new Vector3(enemy.position.x+Time.deltaTime*_direction*speed, 
            enemy.position.y, enemy.position.z);
    }
    private void DirectionChange()
    {
        animator.SetBool("walking", false);
        idletimer += Time.deltaTime;
        if(idletimer>idleDuration)
            movingleft = !movingleft;

    }

}