using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructibleBarrier : MonoBehaviour
{
    public Animator animator;
    public BoxCollider2D boxCollider2D;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("AttackZone"))
        {
            AnimationBreak();
        }
        
    }

    private void AnimationBreak()
    {
        boxCollider2D.enabled = false;
        animator.SetTrigger("Break");
    }
}
