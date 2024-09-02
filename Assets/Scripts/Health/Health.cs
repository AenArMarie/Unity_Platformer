using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [Header ("Health")]
    [SerializeField] private float startingHealth;

    private Animator animator;
    private bool dead = false;
    public float currentHealth { get; private set; }
    [Header("Health")]
    [SerializeField] private float iFramesDuration;
    [SerializeField] private int NumberOfFlashes;

    [SerializeField] private GameObject deathscreen;
    private bool invelnarable = false;
    private SpriteRenderer spriteRenderer;
    private void Awake()
    {
        animator = GetComponent<Animator>();
        currentHealth = startingHealth;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    public void TakeDamage(float _damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - _damage, 0, startingHealth);
        if (currentHealth > 0)
        {
            animator.SetTrigger("hurt");
            StartCoroutine(Invulnerability());
        }
        else
        {
            if (!dead)
            {
                
                

                //Игрок
                if (GetComponent<Movement>()!=null)
                    GetComponent<Movement>().enabled = false;

                //Противник
                if (GetComponent<MeleeGuy>() != null)
                {
                    GetComponent<MeleeGuy>().enabled = false;
                }
                if (GetComponentInParent<EnemyPatrol>() != null)
                    GetComponentInParent<EnemyPatrol>().enabled = false;

                dead = true;
                animator.SetTrigger("die");
            }
            
        }
    }
    public void RestoreHeart()
    {
        if (currentHealth < startingHealth)
        {
            currentHealth += 1;
        }
    }

    public void ResetHealth()
    {
        currentHealth = startingHealth;
        dead = false;
    }
    public void Death()
    {
        if (GetComponent<Movement>() != null)
            deathscreen.SetActive(true);
        if (GetComponent<MeleeGuy>() != null)
        {
            gameObject.SetActive(false);
        }
    }

    private IEnumerator Invulnerability()
    {
        invelnarable = true;
        Physics2D.IgnoreLayerCollision(8, 9, true);
        for (int i = 0; i < NumberOfFlashes; i++)
        {
            spriteRenderer.color = new Color(1, 0, 0, 0.5f);
            yield return new WaitForSeconds(iFramesDuration/(NumberOfFlashes*2));
            spriteRenderer.color = Color.white;
            yield return new WaitForSeconds(iFramesDuration/(NumberOfFlashes*2));
        }
        Physics2D.IgnoreLayerCollision(8, 9, false);
        invelnarable = false;
    }
    public bool check()
    {
        return !invelnarable;
    }

}
