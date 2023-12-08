using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightMovement : MonoBehaviour
{
    public float speed = 2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right * speed * Time.deltaTime);
        if (transform.position.x > 9.6)
        {
            transform.position += new Vector3(-20, 0, 0);
        }
    }

    
}