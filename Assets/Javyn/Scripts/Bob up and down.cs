using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bobupanddown : MonoBehaviour
{
    private bool heading = true;

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y >= 2.5)
        {
            heading = false;
        }

        if (heading)
        {
            transform.Translate(0, 0.1f * Time.deltaTime, 0);
        }

        if (transform.position.y <= 2.25)
        {
            heading = true;
        }

        if (!heading)
        {
            transform.Translate(0, -0.1f * Time.deltaTime, 0);
        }
    }
}
