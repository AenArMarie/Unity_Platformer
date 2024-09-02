using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageOnCollision : MonoBehaviour
{
    [SerializeField] private float damage;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if(collision.GetComponent<Health>().check())
            {
                collision.GetComponent<Health>().TakeDamage(damage);
            }
            
        }
    }
}
