using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TPZone : MonoBehaviour
{
    public string nextZone;
    public string actualZone;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GameManager.gameManager.previousZone = actualZone;
            SceneManager.LoadScene(nextZone);
        }
    }
}
