using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Singleton : MonoBehaviour
{
    public static Singleton singleton;
    
    public double gold = 0;
    public int depthUprage = 1;
    public int cashUpgrade = 1;
    public int spawnUpgrade = 1;
    public int goToStart = 1;
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

    private void Update()
    {
        if (goToStart > 1)
        {
            goToStart = 1;
            SceneManager.LoadScene("Fishing");
        }
    }
}
