using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SceneManagement;

public class PressToStart : MonoBehaviour
{
    void Update()
    {
        if (Input.GetAxisRaw("Buttons1") != 0 || Input.GetAxisRaw("Buttons2") != 0)
        {
            SceneManager.LoadScene("Playscene");
        }       
    }
}
