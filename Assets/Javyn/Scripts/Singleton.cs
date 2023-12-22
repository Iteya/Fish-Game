using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Singleton : MonoBehaviour
{
    public static Singleton Instance;
    
    public double gold = 0;
    public int depthUprage = 1;
    public int cashUpgrade = 1;
    public int spawnUpgrade = 1;
    public int goToStart = 1;
    public double depthCost = 10;
    public double cashCost = 20;
    public double spawnCost = 15;
    public bool show1, show2, show3, show4, show5, show6, show7, show8, show9 = false;
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        } 
    }

    private void Update()
    {
        if (goToStart > 1)
        {
            goToStart = 1;
            SceneManager.LoadScene("Playscene");
        }
        if (gold > 10)
        {
            show1 = true;
        }
        if (gold > 50)
        {
            show2 = true;
        }
        if (gold > 100)
        {
            show3 = true;
        }
        if (gold > 500)
        {
            show4 = true;
        }
        if (gold > 1000)
        {
            show5 = true;
        }
        if (gold > 1500)
        {
            show6 = true;
        }
        if (gold > 3000)
        {
            show7 = true;
        }
        if (gold > 5000)
        {
            show8 = true;
        }
        if (gold > 10000)
        {
            show9 = true;
        }
    }
}
