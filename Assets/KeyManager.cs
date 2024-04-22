using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyManager : MonoBehaviour
{
    [SerializeField] GameObject player;

    public bool isPickedUp;
    private Vector2 vel;
    public float smoothTime;

    public static KeyManager keyManager;

    private void Awake()
    {
        if (keyManager != null)
        {
            Debug.LogWarning("Il y a plus d'une instance de BasicMovement dans la sc�ne");
            return;
        }

        keyManager = this;
    }

    private void Update()
    {
        if (isPickedUp)
        {
            Vector3 offset = new Vector3(-0.5f, 0.5f, 0);
            transform.position = Vector2.SmoothDamp(transform.position, player.transform.position + offset, ref vel, smoothTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player") && !isPickedUp)
        {
            isPickedUp = true;
        }
    }
}
