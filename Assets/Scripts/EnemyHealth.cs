using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    private Animator animator;

    public int enemyHealth = 20;
    public int attackDamage = 10;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void EnemyTakeDamage()
    {
        enemyHealth -= attackDamage;
    }

}
