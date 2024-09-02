using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingScreen : MonoBehaviour
{
    public ScriptMenu menu;
    public void transition()
    {
        menu.gameObject.SetActive(true);

    }
    public void funny()
    {
        gameObject.SetActive(false);
    }
}
