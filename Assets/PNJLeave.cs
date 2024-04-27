using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PNJLeave : MonoBehaviour
{
    public SpriteRenderer PNJgraphics;

    public FadeOut fadeOut;

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.O) && Inventory.inventory.crystalCount>=6)
        {
            Inventory.inventory.RemoveCrystals(6);
            
            fadeOut.StartFadeOut();

            if (fadeOut)
            {
                StartCoroutine(WaitToDestroy());
            }

        }
    }

    private IEnumerator WaitToDestroy()
    {
        yield return new WaitForSeconds(2f);
        gameObject.SetActive(false);
    }
}
