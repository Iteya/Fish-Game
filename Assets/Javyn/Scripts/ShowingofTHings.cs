using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowingofTHings : MonoBehaviour
{
    [SerializeField] public GameObject object1, object2, object3, object4, object5, object6, object7, object8, object9;
    // Start is called before the first frame update
    void Start()
    {
        if (Singleton.Instance.show1)
        {
            object1.SetActive(true);
        }
        if (Singleton.Instance.show2)
        {
            object2.SetActive(true);
        }
        if (Singleton.Instance.show3)
        {
            object3.SetActive(true);
        }
        if (Singleton.Instance.show4)
        {
            object4.SetActive(true);
        }
        if (Singleton.Instance.show5)
        {
            object5.SetActive(true);
        }
        if (Singleton.Instance.show6)
        {
            object6.SetActive(true);
        }
        if (Singleton.Instance.show7)
        {
            object7.SetActive(true);
        }
        if (Singleton.Instance.show8)
        {
            object8.SetActive(true);
        }
        if (Singleton.Instance.show9)
        {
            object9.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
