using Rewired;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{

    public int maxHealth = 100;
    public int currentHealth;

    public float invicibilityFlashDelay = 0.2f;
    public bool isInvicible = false;

    public bool shieldOn = false;

    public Animator animator;

    public SpriteRenderer graphics;
    public HealthBar healthBar;

    public BasicMovement basicMovement;
    
    public Shield shield;
    public float shieldDuration = 10f;
    public ItemFollowPlayer itemFollowPlayer;

    public static PlayerHealth playerHealth;


    
    private void Awake()
    {
        if (playerHealth != null)
        {
            Debug.LogWarning("Il y a plus d'une instance de PlayerHealth dans la sc�ne");
            return;
        }
        playerHealth = this;

        
    }

    void Start()
    {
        
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);

        if (shieldOn == false)
        {
            isInvicible = false;
        }
        else
        {
            isInvicible = true;
        }
    }

    void Update()
    {
       
    }

    public void HealPlayer(int amount)
    {
        if((currentHealth + amount) > maxHealth)
        {
            currentHealth = maxHealth;
        }
        else
        {
            currentHealth += amount;
            healthBar.SetHealth(currentHealth);
        }
        
    }

    public void TakeDamage(int damage)
    {
        if (!isInvicible && shieldOn == false)
        {
            currentHealth -= damage;
            healthBar.SetHealth(currentHealth);

            if(currentHealth <= 0)
            {
                StartCoroutine(Die());
                

            }
            else
            {
                isInvicible = true;

                StartCoroutine(InvicibilityFlash());
                StartCoroutine(HandleInvicibilityDelay());
            }
            
            
        }
        else if (!isInvicible && shield == true)
        {
            currentHealth -= damage/2;
            healthBar.SetHealth(currentHealth);

            if (currentHealth <= 0)
            {
                StartCoroutine(Die());


            }
            else
            {
                isInvicible = true;

                StartCoroutine(InvicibilityFlash());
                StartCoroutine(HandleInvicibilityDelay());
            }
        }
        
    }

    public IEnumerator InvicibilityFlash()
    {
        while (isInvicible)
        {
            graphics.color = new Color(1f, 1f, 1f, 0f);
            yield return new WaitForSeconds(invicibilityFlashDelay);
            graphics.color = new Color(1f, 1f, 1f, 1f);
            yield return new WaitForSeconds(invicibilityFlashDelay);
        }
    }

    public IEnumerator HandleInvicibilityDelay()
    {
        yield return new WaitForSeconds(1.5f);
        isInvicible = false;
    }
    public IEnumerator Die()
    {
        basicMovement.enabled = false;
        animator.SetBool("isDead", true);
        yield return new WaitForSeconds(3f);
        GameOverManager.gameOverManager.OnPlayerDeath();

    }

    public void Respawn()
    {
        basicMovement.enabled = true;
        animator.SetBool("Respawn", true);
        currentHealth = maxHealth;
        healthBar.SetHealth(currentHealth);
    }

    public void IsShielded()
    {
        shieldOn = true;
        shield.SetActiveShield();
        Debug.Log("True");
        //StartCoroutine(ShieldExpired());
        
    }

    public IEnumerator ShieldExpired()
    {
        yield return new WaitForSeconds(shieldDuration);
        shieldOn = false;
        shield.SetNotActiveShield();
        itemFollowPlayer.DestroyCrystalShield();

    }
}
