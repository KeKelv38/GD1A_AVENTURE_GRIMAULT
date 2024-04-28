using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TriggerZoneToOpenDoor : MonoBehaviour
{
    public GameObject door;
    public GameObject target;
    public float speed = 2f;

    private bool canOpen = false;

    public static TriggerZoneToOpenDoor triggerZoneToOpenDoor;

    private void Awake()
    {
        if (triggerZoneToOpenDoor != null)
        {
            Debug.LogWarning("Il y a plus d'une instance de triggerZoneToOpenDoor dans la scène");
            return;
        }

        triggerZoneToOpenDoor = this;
    }

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
           if(KeyManager.keyManager != null) KeyManager.keyManager.CanDestroy();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && KeyManager.keyManager.isPickedUp == true)
        {
            canOpen = true;
        }
    }

    public void OpenDoor()
    {
        door.transform.position = Vector3.MoveTowards(door.transform.position, target.transform.position, speed);
    }
}
