using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float speed;
    private float _direction;
    private bool hit;
    private float lifetime=0;

    private BoxCollider2D boxCollider;
    private Animator animator;
    private void Awake()
    {
        animator = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();
    }
    private void Update()
    {
        if (hit) return;
        float movementSpeed = speed*Time.deltaTime*_direction;
        transform.Translate(movementSpeed, 0, 0);
        lifetime+=Time.deltaTime;
        if (lifetime > 5)
        {
            gameObject.SetActive(false);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        hit = true;
        boxCollider.enabled = false;
        animator.SetTrigger("Explode");
        if(collision.GetComponent<Health>()!=null&&collision.tag=="Enemy")
        {
            collision.GetComponent<Health>().TakeDamage(1);
        }    
    }
    public void SetDirection(float direction)
    {
        lifetime = 0;
        _direction = direction;
        gameObject.SetActive(true);
        hit = false;
        boxCollider.enabled = true;
        float localeScaleX = transform.localScale.x;
        if (Math.Sign(localeScaleX) != _direction)
            localeScaleX = -localeScaleX;
        transform.localScale = new Vector3(localeScaleX, transform.localScale.y, transform.localScale.z);
    }

    private void Deactivate()
    {
        gameObject.SetActive(false);
    }
}
