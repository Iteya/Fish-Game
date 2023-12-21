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
    public GameObject singleton;
    public bool playing = true;
    public float maxFish;
    public float xSpawning;
    void Start()
    {
        maxFish = Singleton.Instance.spawnUpgrade * 2;
        if (maxFish < 20)
        {
            maxFish = maxFish + 20;
        }
        
        StartCoroutine(FishSpawning());
    }

    // Update is called once per frame
    void Update()
    {
        xSpawning = Random.Range(-9.4f, 9.0f);
    }

    IEnumerator FishSpawning()
    {
        while (playing)
        {
            if (fish < maxFish)
            {
                Instantiate(fishes, new Vector3(xSpawning, -5, 0), quaternion.identity);
                fish += 1;
            }

            yield return new WaitForSeconds(2);
        }
    }
}
