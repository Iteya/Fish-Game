using UnityEngine;
using UnityEngine.UI;

public class ImagePicker : MonoBehaviour
{
    [SerializeField] public Sprite image1, image2, image3, image4, image5, image6, image7, image8;
    private Sprite[] images;

    public Image Image;
    // Start is called before the first frame update
    void Start()
    {
        images = new Sprite[8];
        images[0] = image1;
        images[1] = image2;
        images[2] = image3;
        images[3] = image4;
        images[4] = image5;
        images[5] = image6;
        images[6] = image7;
        images[7] = image8;
        if (transform.position.x < 100)
        {
            int num = UnityEngine.Random.Range(4, 7);
            Image.sprite = images[num];
        }

        if (transform.position.y == 0)
        {
            //Instantiate()
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
