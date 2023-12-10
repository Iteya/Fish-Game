using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SceneManagement;

public class PressToStart : MonoBehaviour
{
    public string TargetScene = "Playscene";

    void Update()
    {
        if (Input.GetAxisRaw("Buttons1") != 0 || Input.GetAxisRaw("Buttons2") != 0)
        {
            //SceneManager.LoadScene(TargetScene); <-- Currently BROKEN (talk to owen to fix when you get the chance?
        }       
    }
}
