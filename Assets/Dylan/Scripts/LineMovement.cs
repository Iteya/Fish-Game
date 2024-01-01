using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static TMPro.TextMeshProUGUI;

public class LineMovement : MonoBehaviour
{
    public float xDirection;
    [SerializeField] private int speed;
    [SerializeField] public float yGravity = -0.2f;
    [SerializeField] public int maxFish;
    [SerializeField] public int maxDepth;
    [SerializeField] public int fishCount;
    [SerializeField] public AudioSource bite;
    [SerializeField] public TextMeshProUGUI depthDisplay;
    public GameObject self;
    public GameObject singleton;
    public int cashUpgrades;
    public float depth = 0;
    public float depthMult;

    private void Start()
    {
        singleton = GameObject.FindGameObjectWithTag("Singleton");
        cashUpgrades = Singleton.Instance.cashUpgrade;
    }

    // Update is called once per frame
    void Update()
    {
        depthDisplay.text = Math.Round(depth).ToString();
        xDirection = Input.GetAxisRaw("Horizontal") * speed * Time.deltaTime;
        if (transform.position.y > 2.5)
        {
            transform.Translate(new Vector2(0, yGravity * Time.deltaTime));
        }

        if (transform.position.x >= -8)
        {
            if (xDirection < 0)
            {
                transform.Translate(new Vector3(xDirection, 0, 0));
            }
        } 
        if (transform.position.x <= 8)
        {
            if (xDirection > 0)
            {
                transform.Translate(new Vector3(xDirection, 0, 0));
            }
        }

        depth += 1 * Time.deltaTime * depthMult;
         
        if (depth >= Singleton.Instance.depthUprage * 5 + 30)
        {
            transform.Translate(new Vector2(0, 5 * Time.deltaTime));
            if (transform.position.y > 9.5)
            {
                SceneManager.LoadScene("Shop");
            }
        }

        if (depth >= 999999999)
        {
            transform.Translate(new Vector2(0, 5 * Time.deltaTime));
            if (transform.position.y > 9.5)
            {
                SceneManager.LoadScene("Shop");
            }
        }

        depthMult = 1f;
        if (Input.GetAxis("Buttons1") != 0 || Input.GetAxis("Buttons2") != 0)
        {
            transform.Translate(new Vector2(0, -2 * Time.deltaTime));
            depthMult = 1.5f;
        }

        if (transform.position.y < 2.5)
        {
            transform.Translate(new Vector2(0, 1 * Time.deltaTime));
        }

        if (transform.position.y < .5)
        {
            transform.Translate(new Vector2(0, 1 * Time.deltaTime));
        }

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Destroy(other.gameObject);
        self.GetComponent<FishCollect>().fish -= 1;
        Singleton.Instance.gold += Mathf.Round(1 * (cashUpgrades / 2) + 1);
        bite.Play();
    }
}
