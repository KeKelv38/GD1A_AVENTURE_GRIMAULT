using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructibleBarrier : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("AttackZone"))
        {
            Destroy(this);
        }
        
    }
}
