using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalEnemyMovementHorizontal : MonoBehaviour
{
    [SerializeField] private float MovementDistance;
    [SerializeField] private float MovementSpeed;
    private float leftEdge;
    private float rightEdge;

    private bool MovingLeft=true;
    private void Awake()
    {
        leftEdge = transform.position.x - MovementDistance;
        rightEdge = transform.position.x + MovementDistance;
    }
    void Update()
    {
        if (MovingLeft)
        {
            if (transform.position.x < leftEdge)
            {
                MovingLeft = false;
            }
            else
            {
                transform.position = new Vector3(transform.position.x - MovementSpeed * Time.deltaTime, transform.position.y , transform.position.z);
            }
        }
        else
        {
            if (transform.position.x > rightEdge)
            {
                MovingLeft = true;
            }
            else
            {
                transform.position = new Vector3(transform.position.x + MovementSpeed * Time.deltaTime, transform.position.y , transform.position.z);
            }
        }
    }
}
