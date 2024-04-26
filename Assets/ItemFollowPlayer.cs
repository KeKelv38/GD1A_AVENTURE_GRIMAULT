using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemFollowPlayer : MonoBehaviour
{
    public bool isPickedUp = false;
    public float smoothTime;
    private Vector2 vel;

    public PlayerHealth playerHealth;
    

    public static ItemFollowPlayer instance;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Awake()
    {


        if (instance != null)
        {
            return;
        }

        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (isPickedUp)
        {
            Vector3 offset = new Vector3(-0.5f, 0.5f, 0);
            transform.position = Vector2.SmoothDamp(transform.position, BasicMovement.basicMovement.transform.position + offset, ref vel, smoothTime);
        }

        PickupTrue();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && !isPickedUp)
        {
            isPickedUp = true;
            
        }
    }

    public void PickupTrue()
    {
        if (isPickedUp == true)
        {
            playerHealth.IsShielded();
            
            
        }
    }
}
