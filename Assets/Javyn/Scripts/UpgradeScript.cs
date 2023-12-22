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
    public Singleton singleton = Singleton.Instance;
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
        firstCost = Singleton.Instance.spawnCost;
        secondCost = Singleton.Instance.cashCost;
        thirdCost = Singleton.Instance.depthCost;
    }

    void FishUpgrade()
    {
        if (Singleton.Instance.gold >= FirstButton.GetComponent<varholder>().cost)
        {
            Singleton.Instance.spawnUpgrade += 1;
            Singleton.Instance.gold -= FirstButton.GetComponent<varholder>().cost;
            firstCost = Math.Floor((firstCost * 1.2) + 1);
            Singleton.Instance.spawnCost = firstCost;
            firstSource.Play();
        }
        else
        {
            error.Play();
        }
    }

    void CoinUpgrade()
    {
        if (Singleton.Instance.gold >= SecondButton.GetComponent<varholder>().cost)
        {
            Singleton.Instance.cashUpgrade += 1;
            Singleton.Instance.gold -= SecondButton.GetComponent<varholder>().cost;
            secondCost = Math.Floor((secondCost * 1.2) + 1);
            Singleton.Instance.cashCost = secondCost;
            secondSource.Play();
        }
        else
        {
            error.Play();
        }
    }

    void DepthUpgrade()
    {
        if (Singleton.Instance.gold >= ThirdButton.GetComponent<varholder>().cost)
        {
            Singleton.Instance.depthUprage += 1;
            Singleton.Instance.gold -= ThirdButton.GetComponent<varholder>().cost;
            thirdCost = Math.Floor((thirdCost * 1.2) + 1);
            Singleton.Instance.depthCost = thirdCost;
            thirdSource.Play();
        }
        else
        {
            error.Play();
        }
    }

    void Return()
    {
        Singleton.Instance.goToStart += 1;
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
            yield return new WaitForSeconds(0.3f);
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
