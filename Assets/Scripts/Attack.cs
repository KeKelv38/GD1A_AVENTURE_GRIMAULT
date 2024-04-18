using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    private float attackTime = 0.25f;
    private float attackCounter = 0.25f;
    public bool isAttacking;

    public int attackDamage = 10;

    public CircleCollider2D circleCollider;

    public Animator animator;

    [SerializeField] Transform checkEnemy;


    // Start is called before the first frame update
    void Start()
    {
        circleCollider.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isAttacking)
        {

            attackCounter -= Time.deltaTime;
            if (attackCounter <= 0)
            {
                animator.SetBool("isAttacking", false);
                isAttacking = false;
                circleCollider.enabled = false;
            }
        }

        if (Input.GetMouseButtonDown(0))
        {
            circleCollider.enabled = true;
            attackCounter = attackTime;
            animator.SetBool("isAttacking", true);
            isAttacking = true;
            
        }



        if (Input.GetAxis("Horizontal") > 0.1)
        {
            checkEnemy.position = new Vector2(transform.position.x + 1, transform.position.y);
        }
        else if (Input.GetAxis("Horizontal") < -0.1)
        {
            checkEnemy.position = new Vector2(transform.position.x - 1, transform.position.y);
        }

        if (Input.GetAxis("Vertical") > 0.1)
        {
            checkEnemy.position = new Vector2(transform.position.x, transform.position.y + 1);
        }
        else if (Input.GetAxis("Vertical") < -0.1)
        {
            checkEnemy.position = new Vector2(transform.position.x, transform.position.y - 1);
        }
    }
}
