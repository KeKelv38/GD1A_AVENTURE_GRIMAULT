using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelMove_Ref : MonoBehaviour
{
    public int sceneBuildIndex;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Trigger Entered");

        if (collision.CompareTag("Player"))
        {
            Debug.Log("Switching Scene to " + sceneBuildIndex);
            SceneManager.LoadScene(sceneBuildIndex);
        }
    }
}
