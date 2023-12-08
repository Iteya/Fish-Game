using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using Random = UnityEngine.Random;


public class FishMovement : MonoBehaviour
{
    public float speed = 2;
    public float startPosition = Random.Range(4.34f, -4.39f);
    // Start is called before the first frame update
    void Start()
    {
        transform.position += new Vector3(0, 1, 0);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime);
        if (transform.position.x < -9.6)
        {
            transform.position += new Vector3(20, 0, 0);
            
        }
    }

    
}
