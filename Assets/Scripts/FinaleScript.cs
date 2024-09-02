using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinaleScript : MonoBehaviour
{
    private BoxCollider2D box;
    public GameObject finale;
    public Movement player;
    private void Awake()
    {
        box = GetComponent<BoxCollider2D>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag=="Player")
        {
            player.enabled = false;
            finale.SetActive(true);
        }
    }
}
