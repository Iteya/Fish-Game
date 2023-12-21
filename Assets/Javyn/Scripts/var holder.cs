using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static TMPro.TextMeshProUGUI;

public class varholder : MonoBehaviour
{
    [SerializeField] public Singleton singleton;
    [SerializeField] public double cost;
    public TextMeshProUGUI display;
    

    private void Update()
    {
        string costString = cost.ToString();
        display.text = "cost: " + costString;
        if (Singleton.Instance.gold < cost)
        {
            display.color = Color.red;
        }
        else
        {
            display.color = Color.black;
        }
    }
}
