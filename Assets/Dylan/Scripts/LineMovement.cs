using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineMovement : MonoBehaviour
{ 
    float movementSpeedY;
    float yDirection;
    float yVector;
    float movementSpeedX;
    float xDirection;
    float xVector;
    // Start is called before the first frame update
    void Start()
    {
        movementSpeedY = 5f;
    }

    // Update is called once per frame
    void Update()
    {
        yDirection = Input.GetAxis("Vertical");
        xDirection = Input.GetAxis("Horizontal");
        yVector = yDirection * movementSpeedY * Time.deltaTime;
        transform.position = transform.position + new Vector3(0, yVector, 0);
        xVector = xDirection * movementSpeedX * Time.deltaTime;
        
    }
}