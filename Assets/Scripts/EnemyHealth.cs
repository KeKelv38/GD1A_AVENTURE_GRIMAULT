using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public Animator animator;

    public int enemyHealth = 20;
    public int attackDamage = 10;

    public CircleCollider2D circleCollider;

    void Start()
    {
    }

    private void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        enemyHealth -= attackDamage;
        if(enemyHealth <= 0) 
        {
            StartCoroutine(DeathEnemy());
        }
    }

    IEnumerator DeathEnemy()
    {
        animator.SetBool("isDead", true);
        circleCollider.enabled = false;
        AIChase.instance.enabled = false;
        yield return new WaitForSeconds(2);
    }
}
