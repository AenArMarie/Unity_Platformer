using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeGuy : MonoBehaviour
{
    [SerializeField] private float atkCD;
    [SerializeField] private float range;
    [SerializeField] private int damage;
    [SerializeField] private LayerMask playerLayer;
    [SerializeField] private BoxCollider2D boxCollider;

    private Health player;
    private float cdTimer = Mathf.Infinity;
    private Animator animator;
    private EnemyPatrol enemyPatrol;
    private void Awake()
    {
        animator = GetComponent<Animator>();
        enemyPatrol = GetComponentInParent<EnemyPatrol>();
    }
    private void Update()
    {
        cdTimer += Time.deltaTime;
        if (PlayerInSight())
        {
            if (cdTimer > atkCD)
            {
                cdTimer = 0;
                animator.SetTrigger("meleeatack");
            }
        }
        if(enemyPatrol != null)
        {
            enemyPatrol.enabled = !PlayerInSight();
        }

        
        
    }
    private bool PlayerInSight()
    {
        RaycastHit2D hit = Physics2D.BoxCast(boxCollider.bounds.center + transform.right*range*transform.localScale.x, new Vector3(boxCollider.bounds.size.x*range, boxCollider.bounds.size.y, boxCollider.bounds.size.z),
            0,Vector2.left, 0, playerLayer);
        if (hit.collider != null)
            player = hit.transform.GetComponent<Health>();
        return hit.collider!=null;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(boxCollider.bounds.center + transform.right * range* transform.localScale.x, new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z));
    }

    private void DamagePlayer()
    {
        if(PlayerInSight())
        {
            player.TakeDamage(damage);
        }
    }

}
