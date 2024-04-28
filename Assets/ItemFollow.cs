using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemFollow : MonoBehaviour
{
    private bool isPickedUp = false;
    private float smoothTime = 0.3f;
    private Vector2 vel;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame

    void Update()
    {
        if (isPickedUp)
        {
            Vector3 offset = new Vector3(-0.5f, 0.2f, 0);
            transform.position = Vector2.SmoothDamp(transform.position, BasicMovement.basicMovement.transform.position + offset, ref vel, smoothTime);
        }

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && !isPickedUp)
        {
            isPickedUp = true;

        }
    }
}
