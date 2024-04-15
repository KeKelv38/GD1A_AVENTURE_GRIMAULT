using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HurtPlayer : MonoBehaviour
{

    private float waitToLoad = 2f;
    private bool reloading;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (reloading)
        {
            waitToLoad -= Time.deltaTime;
            if(waitToLoad <= 0)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.collider.tag == "Player")
        {
            //Destroy(other.gameObject);
            other.gameObject.SetActive(false);
            reloading = true;
        }
    }
}
