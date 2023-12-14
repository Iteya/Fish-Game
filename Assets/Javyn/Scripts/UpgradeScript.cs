using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeScript : MonoBehaviour
{
    public Button FirstButton, SecondButton, ThirdButton, ReturnButton;
    public double firstCost;
    public double secondCost;
    public double thirdCost;
    public Singleton singleton;
    public Button[] buttons;
    private int selectedIndex = 0;
    private bool canSwitch = true;
    private bool canClick = true;

    [SerializeField] private AudioSource firstSource;
    [SerializeField] private AudioSource secondSource;
    [SerializeField] private AudioSource thirdSource;
    [SerializeField] private AudioSource error;

    // Start is called before the first frame update
    void Start()
    {
        FirstButton.onClick.AddListener(FishUpgrade);
        SecondButton.onClick.AddListener(CoinUpgrade);
        ThirdButton.onClick.AddListener(DepthUpgrade);
        ReturnButton.onClick.AddListener(Return);
        firstCost = FirstButton.GetComponent<varholder>().cost;
        secondCost = SecondButton.GetComponent<varholder>().cost;
        thirdCost = ThirdButton.GetComponent<varholder>().cost;
    }

    void FishUpgrade()
    {
        if (singleton.gold >= FirstButton.GetComponent<varholder>().cost)
        {
            singleton.spawnUpgrade += 1;
            singleton.gold -= FirstButton.GetComponent<varholder>().cost;
            firstCost = Math.Floor((firstCost * 1.2) + 1);
            firstSource.Play();
        }
        else
        {
            error.Play();
        }
    }

    void CoinUpgrade()
    {
        if (singleton.gold >= SecondButton.GetComponent<varholder>().cost)
        {
            singleton.cashUpgrade += 1;
            singleton.gold -= SecondButton.GetComponent<varholder>().cost;
            secondCost = Math.Floor((secondCost * 1.2) + 1);
            secondSource.Play();
        }
        else
        {
            error.Play();
        }
    }

    void DepthUpgrade()
    {
        if (singleton.gold >= ThirdButton.GetComponent<varholder>().cost)
        {
            singleton.depthUprage += 1;
            singleton.gold -= ThirdButton.GetComponent<varholder>().cost;
            thirdCost = Math.Floor((thirdCost * 1.2) + 1);
            thirdSource.Play();
        }
        else
        {
            error.Play();
        }
    }

    void Return()
    {
        singleton.goToStart += 1;
        thirdSource.Play();
    }

    private void Update()
    {
        FirstButton.GetComponent<varholder>().cost = firstCost;
        SecondButton.GetComponent<varholder>().cost = secondCost;
        ThirdButton.GetComponent<varholder>().cost = thirdCost;

        float horizontalInput = Input.GetAxis("Horizontal");
        if (horizontalInput > 0)
        {
            StartCoroutine(SwitchButton(1));
        }
        else if (horizontalInput < 0)
        {
            StartCoroutine(SwitchButton(-1));
        }

        if (Input.GetAxis("Buttons1") != 0 || Input.GetAxis("Buttons2") != 0)
        {
            StartCoroutine(Click());
        }

        HighlightSelectedButton();
    }

    private IEnumerator SwitchButton(int direction)
    {
        if (canSwitch)
        {
            if (selectedIndex + direction == -1)
            {
                selectedIndex = 3;
            }
            else
            {
                selectedIndex = (selectedIndex + direction) % buttons.Length;
            }
            canSwitch = false;
            yield return new WaitForSeconds(0.5f);
            canSwitch = true;
        }
    }

    private IEnumerator Click()
    {
        if (canClick)
        {
            canClick = false;
            buttons[selectedIndex].onClick.Invoke();
            yield return new WaitForSeconds(0.4f);
            canClick = true;
        }
    }

    void HighlightSelectedButton()
    {
        for (int i = 0; i < buttons.Length; i++)
        {
            if (i == selectedIndex)
            {
                buttons[i].image.color = Color.yellow;
            }
            else
            {
                buttons[i].image.color = Color.white;
            }
        }
    }
}
