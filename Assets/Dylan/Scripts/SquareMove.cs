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

    public float timer = 0;
    // Start is called before the first frame update
    void Start()
    {
    }   

    // Update is called once per frame
    void Update()
    {
        timer += 1 * Time.deltaTime;
        transform.Translate(new Vector2(Input.GetAxis("Horizontal") * -6 * Time.deltaTime, speed * Time.deltaTime));

        if (transform.position.y > 199 && canClonex)
        {
            Instantiate(self, new Vector2(transform.position.x, -210), quaternion.identity);
            canClonex = false;
        }

        if (transform.position.x >= 818)
        {
            transform.position = new Vector2(409, transform.position.y);
        }

        if (transform.position.x <= -818)
        {
            transform.position = new Vector2(409, transform.position.y);
        }

        if (timer > 5000)
        {
            Destroy(self);
        }
    }
}
