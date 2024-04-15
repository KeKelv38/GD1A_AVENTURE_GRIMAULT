using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Basic_Movement : MonoBehaviour
{
    public Animator animator;
    [SerializeField] public float Movespeed = 5f;

    private float attackTime = 0.25f;
    private float attackCounter = 0.25f;
    private bool isAttacking;


    void Update()
    {
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0.0f) * Movespeed;

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Magnitude", movement.magnitude);

        transform.position = transform.position + movement * Time.deltaTime;

        if(animator.GetFloat("Horizontal") == 1)
        {
            animator.SetFloat("lastMoveX", animator.GetFloat("Horizontal"));
        }

        if (animator.GetFloat("Vertical") == 1)
        {
            animator.SetFloat("lastMoveY", animator.GetFloat("Vertical"));
        }

        if (isAttacking)
        {

            attackCounter -= Time.deltaTime;
            if(attackCounter <= 0)
            {
                animator.SetBool("isAttacking", false);
                isAttacking = false;
            }
        }

        if (Input.GetMouseButtonDown(0))
        {
            attackCounter = attackTime;
            animator.SetBool("isAttacking", true);
            isAttacking = true;
        }
    }

}
