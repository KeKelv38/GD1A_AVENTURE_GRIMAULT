using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerZoneToOpenDoor : MonoBehaviour
{
    public GameObject door;
    public GameObject target;
    public float speed = 2f;

    private bool canOpen = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (canOpen)
        {
            OpenDoor();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && KeyManager.keyManager.isPickedUp == true)
        {
            canOpen = true;
        }
    }

    private void OpenDoor()
    {
        door.transform.position = Vector3.MoveTowards(door.transform.position, target.transform.position, speed);
    }
}
