using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalEnemyMovement : MonoBehaviour
{
    [SerializeField] private float MovementDistance;
    [SerializeField] private float MovementSpeed;
    private float bottomEdge;
    private float topEdge;

    private bool MovingDown = true;
    private void Awake()
    {
        bottomEdge = transform.position.y - MovementDistance;
        topEdge = transform.position.y + MovementDistance;
    }
    void Update()
    {
        if (MovingDown)
        {
            if (transform.position.y < bottomEdge)
            {
                MovingDown = false;
            }
            else
            {
                transform.position = new Vector3(transform.position.x , transform.position.y - MovementSpeed * Time.deltaTime, transform.position.z);
            }
        }
        else
        {
            if (transform.position.y > topEdge)
            {
                MovingDown = true;
            }
            else
            {
                transform.position = new Vector3(transform.position.x , transform.position.y + MovementSpeed * Time.deltaTime, transform.position.z);
            }
        }
    }
}
