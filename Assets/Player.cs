using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    public bool left, right, up, down;
    [SerializeField] int speed;
    Rigidbody2D rb;
    Animator animator;
    [SerializeField] GameObject manager;
    [SerializeField] GameObject bullet;
    public GameObject myPrefab;
    float timeWaited = 0;

    private static GameObject original = null;

    private void Awake()
    {
        if (original == null)
            original = gameObject;
        if (gameObject != original)
            Destroy(gameObject);
    }

    void Start()
    {
        manager = GameObject.FindGameObjectsWithTag("manager")[0];
        DontDestroyOnLoad(this);
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        rb.freezeRotation = true;
        myPrefab.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && manager.GetComponent<Manager>().slotSelected == 1)
        {
            Debug.Log("PLOP");
            StartCoroutine(SwingAttack());
            //animator.SetBool("swing", true);
        }
        timeWaited += 1000 * Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.Space) && timeWaited > 150f && manager.GetComponent<Manager>().slotSelected == 2 && GetComponent<SpriteRenderer>().flipX == false)
        {
            GameObject b = Instantiate(bullet, transform.position + transform.right * 1f, transform.rotation);
            timeWaited = 0;
            b.GetComponent<Rigidbody2D>().velocity = b.transform.right * 200f;
        }
        if (Input.GetKeyDown(KeyCode.Space) && timeWaited > 150f && manager.GetComponent<Manager>().slotSelected == 2 && GetComponent<SpriteRenderer>().flipX == true)
        {
            GameObject b = Instantiate(bullet, transform.position -transform.right * 1f, transform.rotation);
            timeWaited = 0;
            b.GetComponent<Rigidbody2D>().velocity = b.transform.right * -200f;
        }
        if (Input.GetKeyDown(KeyCode.Space) && manager.GetComponent<Manager>().slotSelected == 3 && manager.GetComponent<Manager>().item3Amount > 0)
        {
            Debug.Log(manager.GetComponent<Manager>().item3Amount);
            myPrefab.SetActive(true);
            //manager.GetComponent<Manager>().item3Amount--;
        }

        if (Input.GetKeyDown(KeyCode.Space) && manager.GetComponent<Manager>().slotSelected == 5 && manager.GetComponent<Manager>().item5Amount > 0)
        {
            int xcount = Random.Range(1, 7); // 100 200 ... 600

            manager.GetComponent<Manager>().coins += (xcount * 100);
            manager.GetComponent<Manager>().item5Amount--;
        }



        if (left || right || up || down)
        {
            animator.SetBool("moving", true);
        }
        else
            animator.SetBool("moving", false);
        if(left)
        {
            GetComponent<SpriteRenderer>().flipX = true;
            
        }
        if(right)
        {
            GetComponent <SpriteRenderer>().flipX = false;
            
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            //animator.SetBool("moving", true);
            up = true; }
        if (Input.GetKeyDown(KeyCode.S))
        {
            //animator.SetBool("moving", true);
            down = true; }
        if (Input.GetKeyDown(KeyCode.A))
        {
            //animator.SetBool("moving", true);
            left = true; }
        if (Input.GetKeyDown(KeyCode.D))
        {
            //animator.SetBool("moving", true);
            right = true; }

        if (Input.GetKeyUp(KeyCode.W))
        {
            //animator.SetBool("moving", false);
            up = false; }
        if (Input.GetKeyUp(KeyCode.S))
        {
            //animator.SetBool("moving", false);
            down = false; }
        if (Input.GetKeyUp(KeyCode.A))
        {
            //animator.SetBool("moving", false);
            left = false; }
        if (Input.GetKeyUp(KeyCode.D))
        {
            //animator.SetBool("moving", false);
            right = false; }
    }
    private void FixedUpdate()
    {
        Vector2 dir = Vector2.zero;

        if (up)
            dir += new Vector2(0, speed * Time.deltaTime);
        if (down)
            dir += new Vector2(0, -speed * Time.deltaTime);
        if (left)
            dir += new Vector2(-speed * Time.deltaTime, 0);
        if (right)
            dir += new Vector2(speed * Time.deltaTime, 0);
        rb.velocity = dir;

        
    }
    private IEnumerator SwingAttack()
    {
        animator.SetBool("swing", true);
        Debug.Log("PLAYING");
        yield return new WaitForSeconds(1f);
        animator.SetBool("swing", false);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag.Equals("forestBlock"))
        { 
            SceneManager.LoadScene(1);
            transform.position = new Vector3(transform.position.x, -40.86388f, transform.position.z);
        }
        if (collision.gameObject.tag.Equals("villageBlock"))
        {
            SceneManager.LoadScene(0);
            transform.position = new Vector3(transform.position.x, 65.88053f, transform.position.z);
        }
        if(collision.gameObject.tag.Equals("enterMarketBlock"))
        {
            SceneManager.LoadScene(2);
            up = false;
            down = false;
            right = false;
            left = false;
            transform.position = new Vector3(-60.9165f, -28.62833f, transform.position.z);
        }
        if (collision.gameObject.tag.Equals("exitMarket"))
        {
            SceneManager.LoadScene(0);
        }
        if (collision.gameObject.tag.Equals("enterPotionShopBlock"))
        {
            SceneManager.LoadScene(3);
            up = false;
            down = false;
            right = false;
            left = false;
            transform.position = new Vector3(-60.9165f, -28.62833f, transform.position.z);
        }
        if (collision.gameObject.tag.Equals("exitConsumableShop"))
        {
            SceneManager.LoadScene(0);
        }
    }
}
