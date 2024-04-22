using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerToMove : MonoBehaviour
{
    public GameObject pierre;
    public GameObject destination;
    public float speed = 2f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            pierre.transform.position = Vector3.MoveTowards(pierre.transform.position, destination.transform.position, speed);
        }
        
    }

    private void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            pierre.transform.position = Vector3.MoveTowards(pierre.transform.position, destination.transform.position, speed);
        }
    }
}
