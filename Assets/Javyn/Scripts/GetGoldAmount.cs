using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static TMPro.TextMeshProUGUI;

public class GetGoldAmount : MonoBehaviour
{
    public TextMeshProUGUI display;
    // Start is called before the first frame update
    void Start()
    {
        /* string costString = cost.ToString();
        display.text = "cost: " + costString;*/
    }

    // Update is called once per frame
    void Update()
    {
        string gold = Singleton.Instance.gold.ToString();
        display.text = ("Gold: " + gold);
    }
}
