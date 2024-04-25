using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TpEndZone : MonoBehaviour
{

    public string lastZone;
    // Start is called before the first frame update
    void Start()
    {
        if(lastZone == GameManager.gameManager.previousZone)
        {
            GameObject.FindGameObjectWithTag("Player").transform.position = transform.position;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
