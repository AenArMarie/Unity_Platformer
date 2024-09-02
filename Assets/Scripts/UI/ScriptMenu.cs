using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptMenu : MonoBehaviour
{
    public Movement player;
    public Health health;
    public GameObject[] levels;
    public PlayerAttack attack;
    private void Awake()
    {
        player.enabled = false;
        attack.enabled = false;
        health.enabled = false;

        foreach (GameObject level in levels)
        {
            level.SetActive(false);
        }
        
    }

    public void button1()
    {
        foreach (GameObject level in levels)
        {
            level.SetActive(false);
        }
        levels[0].SetActive(true);
        player.transform.position = Vector3.zero;
        player.enabled = true;
        attack.enabled = true;
        health.enabled = true;
        health.ResetHealth();
        gameObject.SetActive(false);
    }
    public void button2()
    {
        foreach (GameObject level in levels)
        {
            level.SetActive(false);
        }
        levels[1].SetActive(true);
        player.transform.position = Vector3.zero;
        attack.enabled = true;
        player.enabled = true;
        health.enabled = true;
        health.ResetHealth();
        gameObject.SetActive(false);
    }
    public void button3()
    {
        foreach (GameObject level in levels)
        {
            level.SetActive(false);
        }
        levels[2].SetActive(true);
        player.transform.position = Vector3.zero;
        attack.enabled = true;
        player.enabled = true;
        health.enabled = true;
        health.ResetHealth();
        gameObject.SetActive(false);
    }

    public void quit()
    {
       Application.Quit();
    }
}
