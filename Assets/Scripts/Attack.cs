using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Attack : MonoBehaviour
{
    public GameObject Melee;
    bool isAttacking = false;
    float attDuration = 0.3f;
    float attTimer = 0f;

    private void Update()
    {
        CheckMeleeTimer();
        if (Input.GetMouseButton(0))
        {
            OnAttack();
        }
    }

    void OnAttack()
    {
        if (!isAttacking)
        {
            Melee.SetActive(true);
            isAttacking = true;
            //animation
        }
    }

    void CheckMeleeTimer()
    {
        if (isAttacking)
        {
            attTimer += Time.deltaTime;
            if(attTimer >= attDuration)
            {
                attTimer = 0;
                isAttacking = false;
                Melee.SetActive(false);
            }
        }
    }
}
