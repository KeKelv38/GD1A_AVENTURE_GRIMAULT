using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] GameObject shieldObject;



    public static Shield shield;

    private void Awake()
    {
        if (shield != null)
        {
            Debug.LogWarning("Il y a plus d'une instance de shield dans la scène");
            return;
        }
        shield = this;
    }




    // Start is called before the first frame update
    void Start()
    {
        shieldObject.SetActive(false);
        transform.position = BasicMovement.basicMovement.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = BasicMovement.basicMovement.transform.position;
    }

    public void SetActiveShield()
    {
        shieldObject.SetActive(true);
        Debug.Log("Le shield est activer");
        yield return new WaitForSeconds(10f);
        SetNotActiveShield();

    }

    public void SetNotActiveShield()
    {
        shieldObject.SetActive(false);

    }





}
