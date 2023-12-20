using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class FishMove : MonoBehaviour
{
    [SerializeField] public Sprite image1, image2, image3, image4;
    private Sprite[] images;
    public int direction;

    public GameObject self;
    // Start is called before the first frame update
    void Start()
    {
        images = new Sprite[4];
        images[0] = image1;
        images[1] = image2;
        images[2] = image3;
        images[3] = image4;
        int num = Random.Range(0, 3);
        self.GetComponent<SpriteRenderer>().sprite = images[num];
        transform.rotation = new Quaternion(0, 0, 0.08716f, 0.99618f);
        Debug.Log(transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < -9.4f)
        {
            direction = 1;
            transform.localScale = new Vector3(0.75f, 0.75f, 1);
        }

        if (transform.position.x > 9)
        {
            direction = -1;
            transform.localScale = new Vector3(-0.75f, 0.75f, 1);
        }
        transform.Translate(new Vector2(1f * Time.deltaTime * direction, 0.1f * Time.deltaTime));
    }
}
