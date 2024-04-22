using UnityEngine;

public class CrystalGreenHeal : MonoBehaviour
{

    public int healtPoints;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if(PlayerHealth.playerHealth.currentHealth != PlayerHealth.playerHealth.maxHealth)
            {
                PlayerHealth.playerHealth.HealPlayer(healtPoints);
                Destroy(gameObject);
            }
            
        }
    }
}
