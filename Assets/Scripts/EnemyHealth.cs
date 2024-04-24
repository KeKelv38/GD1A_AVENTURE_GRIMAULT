using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public Animator animator;

    public int enemyHealth = 10;

    public CircleCollider2D circleCollider;

    public GameObject itemToDrop;

    public AIChase aIChase;

    void Start()
    {
        
    }

    private void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("AttackZone"))
        {
            enemyHealth -= Attack.attack.attackDamage;
            if (enemyHealth <= 0)
            {
                StartCoroutine(DeathEnemy());
            }
        }
    }

    IEnumerator DeathEnemy()
    {
        animator.SetTrigger("isDead");
        circleCollider.enabled = false;
        this.GetComponent<AIChase>().enabled = false;
        aIChase.enabled = false;
        DropItem();
        yield return new WaitForSeconds(2);
    }

    private void DropItem()
    {
        // V�rifier si l'objet � laisser tomber est d�fini
        if (itemToDrop != null)
        {
            // Instancier l'objet � la position de l'ennemi
            Instantiate(itemToDrop, transform.position, Quaternion.identity);
        }
        else
        {
            Debug.LogWarning("Aucun objet � laisser tomber n'est d�fini pour cet ennemi !");
        }
    }


}
