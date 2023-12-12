using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeScript : MonoBehaviour
{
    public Button FirstButton, SecondButton, ThirdButton;
    public Singleton singleton;
    // Start is called before the first frame update
    void Start()
    {
        FirstButton.onClick.AddListener(FishUpgrade);
        SecondButton.onClick.AddListener(CoinUpgrade);
        ThirdButton.onClick.AddListener(DepthUpgrade);
    }

    void FishUpgrade()
    {
        if (singleton.gold >= FirstButton.GetComponent<varholder>().cost)
        {
            singleton.spawnUpgrade += 1;
            singleton.gold -= FirstButton.GetComponent<varholder>().cost;
        }
    }

    void CoinUpgrade()
    {
        if (singleton.gold >= SecondButton.GetComponent<varholder>().cost)
        {
            singleton.cashUpgrade += 1;
            singleton.gold -= SecondButton.GetComponent<varholder>().cost;
        }
    }

    void DepthUpgrade()
    {
        if (singleton.gold >= ThirdButton.GetComponent<varholder>().cost)
        {
            singleton.depthUprage += 1;
            singleton.gold -= ThirdButton.GetComponent<varholder>().cost;
        }
    }
}
