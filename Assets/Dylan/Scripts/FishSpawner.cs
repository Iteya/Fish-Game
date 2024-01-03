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
    public float xSpawning = 9;
    public float ySpawning = -9;
    public float fishTimer;
    void Start()
    {
        maxFish = Singleton.Instance.spawnUpgrade * 2;
        if (maxFish < 20)
        {
            maxFish = maxFish + 20;
        }

        fishTimer = 2 * Mathf.Exp(-0.001f * (float)Math.Pow(Singleton.Instance.spawnUpgrade, 2f));
        StartCoroutine(FishSpawning());
        
    }

    // Update is called once per frame
    void Update()
    {
        xSpawning = Random.Range(-9.4f, 9.0f);
        ySpawning = Random.Range(-5, -9);
    }

    IEnumerator FishSpawning()
    {
        while (playing)
        {
            if (fish < maxFish)
            {
                Instantiate(fishes, new Vector3(xSpawning, ySpawning, 0), quaternion.identity);
                fish += 1;
            }

            yield return new WaitForSeconds(fishTimer);
        }
    }
}
