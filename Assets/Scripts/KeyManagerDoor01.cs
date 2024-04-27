using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyManager : MonoBehaviour
{
    [SerializeField] GameObject player;

    public bool isPickedUp;
    private Vector2 vel;
    public float smoothTime;

    public bool exist = true;

    public static KeyManager keyManager;

    private void Awake()
    {
        if (keyManager != null)
        {
            Debug.LogWarning("Il y a plus d'une instance de keyManager dans la scène");
            return;
        }

        keyManager = this;
    }

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }


    private void Update()
    {
        if (isPickedUp && exist)
        {
            Vector3 offset = new Vector3(-0.5f, 0.5f, 0);
            transform.position = Vector2.SmoothDamp(transform.position, player.transform.position + offset, ref vel, smoothTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player") && !isPickedUp && exist)
        {
            isPickedUp = true;
        }
    }

    public void CanDestroy()
    {
        exist = false;
        Destroy(gameObject);
    }
}
