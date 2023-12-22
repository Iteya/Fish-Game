using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using static TMPro.TextMeshProUGUI;

public class DepthOMeter : MonoBehaviour
{
    public float depth = 0;

    public TextMeshProUGUI meter;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        depth += 1 * Time.deltaTime;
        string depthString = Math.Round(depth).ToString();
        meter.text = ("Depth: " + depthString);
    }
}
