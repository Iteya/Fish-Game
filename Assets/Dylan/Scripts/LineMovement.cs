using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineMovement : MonoBehaviour
{
    public float xDirection;
    [SerializeField] private int speed;
    [SerializeField] public float yGravity = -0.2f;
    [SerializeField] public int maxFish;
    [SerializeField] public int maxDepth;
    [SerializeField] public int fishCount;

    // Update is called once per frame
    void Update()
    {
        xDirection = Input.GetAxisRaw("Horizontal") * speed * Time.deltaTime;
        if (transform.position.y > 2.5)
        {
            transform.Translate(new Vector2(0, yGravity * Time.deltaTime));
        }

        if (transform.position.x >= -9)
        {
            if (xDirection < 0)
            {
                transform.Translate(new Vector3(xDirection, 0, 0));
            }
        } 
        if (transform.position.x <= 9)
        {
            if (xDirection > 0)
            {
                transform.Translate(new Vector3(xDirection, 0, 0));
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        FishMove fish = other.gameObject.GetComponent<FishMove>();
        fishCount -= 1;
        if (CompareTag("Fish"))
        {
            Destroy(fish);
        }
    }
}
