using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishCollect : MonoBehaviour
{
    // Start is called before the first frame update
    public int fish;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (gameObject.CompareTag("Fish"))
        {
            Destroy(this.gameObject);
            fish += 1;
            Debug.Log("Fish Collected");
        }
    }
}
