using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineMovement : MonoBehaviour
{
    [SerializeField] public float yGravity = -0.2f;
    [SerializeField] public int maxFish;
    [SerializeField] public int maxDepth;
    [SerializeField] public int fishCount;

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y > 2.5)
        {
            transform.Translate(new Vector2(0, yGravity * Time.deltaTime));
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        FishMove fish = other.gameObject.GetComponent<FishMove>();
        fishCount -= 1;
        if (CompareTag("Fish"))
        {
            Destroy(fish);
        }
    }
}
