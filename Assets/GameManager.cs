using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager gameManager;

    public string previousZone;

    private void Awake()
    {
        if (gameManager != null)
        {
            Debug.LogWarning("Il y a plus d'une instance de gameManager dans la scène");
            return;
        }
        gameManager = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
