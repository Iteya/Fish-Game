using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineMovement : MonoBehaviour
{
    // Start is called before the first frame update
    float movementSpeed;
    float yDirection;
    float yVector;
    void Start()
    {
        movementSpeed = 5f;
    }

    // Update is called once per frame
    void Update()
    {
        yDirection = Input.GetAxis("Vertical");
        yVector = yDirection * movementSpeed * Time.deltaTime;
        transform.position = transform.position + new Vector3(0, yVector, 0);
    }
}
