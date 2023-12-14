using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PressToStart : MonoBehaviour
{
    [SerializeField] private GameObject Fadeout;
    void Update()
    {
        if (Input.GetAxisRaw("Buttons1") != 0 || Input.GetAxisRaw("Buttons2") != 0)
        {
            StartCoroutine(FadeToStart());
        }       
    }

    IEnumerator FadeToStart()
    {
        if (Fadeout.transform.position.y <= 0)
        {
            Fadeout.transform.Translate(new Vector2(0, 0.5f));
            yield return new WaitForSeconds(0.5f);
        } else if (Fadeout.transform.position.y >= 0)
        {
            SceneManager.LoadScene("Playscene");
        }
    }
}
