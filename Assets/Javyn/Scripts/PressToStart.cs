using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PressToStart : MonoBehaviour
{
    [SerializeField] private GameObject Fadeout;
    public bool DoFade = false;
    void Update()
    {
        if (Input.GetAxisRaw("Buttons1") != 0 || Input.GetAxisRaw("Buttons2") != 0)
        {
            DoFade = true;
        }
        if (DoFade)
        {
            Fadeout.transform.Translate(new Vector2(0, 100f * Time.deltaTime));
        }
        if (Fadeout.transform.position.y >= 0)
        {
            SceneManager.LoadScene("Playscene");
        }
    }
}
