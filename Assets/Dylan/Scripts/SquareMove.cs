using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class SquareMove : MonoBehaviour
{
    [SerializeField] private int speed;
    private bool canClonex = true;
    private bool canCloney = true;
    [SerializeField] private GameObject self;
    // Start is called before the first frame update
    void Start()
    {
    }   

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector2(Input.GetAxis("Horizontal") * -2 * Time.deltaTime, speed * Time.deltaTime));

        if (transform.position.y > 199 && canClonex)
        {
            Instantiate(self, new Vector2(transform.position.x, -210), quaternion.identity);
            canClonex = false;
        }

        if (transform.position.x >= 190)
        {
            Instantiate(self, new Vector2(-219, transform.position.y), quaternion.identity);
            canCloney = false;
        }

        if (transform.position.x <= -190)
        {
            Instantiate(self, new Vector2(219, transform.position.y), quaternion.identity);
            canCloney = false;
        }
    }
}
