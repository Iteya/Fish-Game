using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton : MonoBehaviour
{
    public static Singleton singleton;
    
    public int gold = 0;
    public int depthUprage = 1;
    public int cashUpgrade = 1;
    public int spawnUpgrade = 1;
    private void Awake()
    {
        if (singleton != null && singleton != this)
        {
            Destroy(gameObject);
        }
        else
        {
            singleton = this;
            DontDestroyOnLoad(gameObject);
        } 
    }
}
