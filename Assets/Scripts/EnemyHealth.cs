using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public Animator animator;

    public int enemyHealth = 100;

    public CircleCollider2D circleCollider;

    public Attack attack;

    void Start()
    {

    }

    private void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        enemyHealth -= attack.attackDamage;
        if(enemyHealth <= 0) 
        {
            StartCoroutine(DeathEnemy());
        }
    }

    IEnumerator DeathEnemy()
    {
        animator.SetTrigger("isDead");
        circleCollider.enabled = false;
        yield return new WaitForSeconds(2);
    }
}
