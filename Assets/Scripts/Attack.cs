using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    private float attackTime = 0.7f;
    private float attackCounter = 1f;
    public bool isAttacking;

    public int attackDamage = 10;

    public CircleCollider2D circleCollider;

    public Animator animator;

    [SerializeField] Transform checkEnemy;

    public static Attack attack;

    private void Awake()
    {
        if (attack != null)
        {
            Debug.LogWarning("Il y a plus d'une instance de Attack dans la scène");
            return;
        }
        attack = this;
    }



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

        if (Input.GetKeyDown(KeyCode.Return) && !PauseMenu.isPaused)
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
