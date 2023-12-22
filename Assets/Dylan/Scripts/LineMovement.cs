using UnityEngine;
using UnityEngine.SceneManagement;

public class LineMovement : MonoBehaviour
{
    public float xDirection;
    [SerializeField] private int speed;
    [SerializeField] public float yGravity = -0.2f;
    [SerializeField] public int maxFish;
    [SerializeField] public int maxDepth;
    [SerializeField] public int fishCount;
    [SerializeField] private AudioSource bite;
    public GameObject self;
    public GameObject singleton;
    public int cashUpgrades;
    public float depth = 0;

    private void Start()
    {
        singleton = GameObject.FindGameObjectWithTag("Singleton");
        cashUpgrades = Singleton.Instance.cashUpgrade;
    }

    // Update is called once per frame
    void Update()
    {
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

        depth += 1 * Time.deltaTime;
         
        if (depth >= Singleton.Instance.depthUprage * 5 + 30)
        {
            transform.Translate(new Vector2(0, 5 * Time.deltaTime));
            if (transform.position.y > 9.5)
            {
                SceneManager.LoadScene("NewShop");
            }
        }
        if (Input.GetAxis("Buttons1") != 0 || Input.GetAxis("Buttons2") != 0)
        {
            transform.Translate(new Vector2(0, -2 * Time.deltaTime));
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
