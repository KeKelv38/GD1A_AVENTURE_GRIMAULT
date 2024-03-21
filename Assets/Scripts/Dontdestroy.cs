using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dontdestroy : MonoBehaviour
{
    private void Start()
    {
        DontDestroyOnLoad(this);
    }
}
