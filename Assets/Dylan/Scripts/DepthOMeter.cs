using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using static TMPro.TextMeshProUGUI;

public class DepthOMeter : MonoBehaviour
{
    public float depth = 0;
    public float depthMult;

    public TextMeshProUGUI meter;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        depth += 1 * Time.deltaTime * depthMult;
        depthMult = 1;
        string depthString = Math.Round(depth).ToString();
        meter.text = ("Depth: " + depthString);
        if (Input.GetAxis("Buttons1") != 0 || Input.GetAxis("Buttons2") != 0)
        {
            depthMult = 1.5f;
        }
    }
}
