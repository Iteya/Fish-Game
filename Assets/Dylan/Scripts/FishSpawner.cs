using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;


public class FishCollect : MonoBehaviour
{
    // Start is called before the first frame update
    public int fish;
    public GameObject fishes;
    public float range;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Instantiate(fishes, new Vector3(Random.Range(-9.4f, 9.0f), -4, 0), quaternion.identity);
    }
}
