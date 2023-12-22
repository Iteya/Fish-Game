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
            StartCoroutine(FadeToStart());
            DoFade = true;
        }       
    }

    IEnumerator FadeToStart()
    {
        while (DoFade)
        {
            Fadeout.transform.Translate(new Vector2(0, 0.3f));
            if (Fadeout.transform.position.y >= 0)
            {
                SceneManager.LoadScene("Playscene");
            }
            yield return new WaitForSeconds(0.5f);
        }
        
    }
}
