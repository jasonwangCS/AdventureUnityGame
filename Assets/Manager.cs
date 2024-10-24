using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Camera camera;
    [SerializeField] GameObject player;
    [SerializeField] GameObject slot2picture;
    [SerializeField] GameObject slot3picture;
    [SerializeField] GameObject slot4picture;
    [SerializeField] GameObject slot5picture;
    private static GameObject original = null;
    public int slotSelected = 1;
    public int item1Amount = 1;
    public int item2Amount = 0;
    public int item3Amount = 0;
    public int item4Amount = 0;
    public int item5Amount = 0;
    [SerializeField] GameObject item2;
    [SerializeField] GameObject item3;
    [SerializeField] GameObject item4;
    [SerializeField] GameObject item5;
    public int coins = 10000;
    [SerializeField] UnityEngine.UI.Text coinText;
    [SerializeField] GameObject zombiePrefab;
    public float time = 0f;
    public float health = 5;

    private void Awake()
    {
        if (original == null)
            original = gameObject;
        if (gameObject != original)
            Destroy(gameObject);
    }
    void Start()
    {
        DontDestroyOnLoad(this);
        //DontDestroyOnLoad(camera);
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime * 1000f;
        if(SceneManager.GetActiveScene().buildIndex == 1)
        {
            //spawn zombie in middle every x seconds;
            if(time > 3000f)
            {
                Instantiate(zombiePrefab, new Vector3(-46.9f, 6.1f, 0f), Quaternion.identity);
                time = 0f;
            }
            
        }
        coinText.text = "Coins: " + coins;
        if(item2Amount > 0)
        {
            slot2picture.SetActive(true);
        }
        else
            slot2picture.SetActive(false);
        if (item3Amount > 0)
        {
            slot3picture.SetActive(true);
        }
        else
            slot3picture.SetActive(false);
        if (item4Amount > 0)
        {
            slot4picture.SetActive(true);
        }
        else
            slot4picture.SetActive(false);
        if(item5Amount > 0)
        {
            slot5picture.SetActive(true);
        }
        else
            slot5picture.SetActive(false);

        if(Input.GetKeyDown("" + 1))
        {
            slotSelected = 1;
        }
        else if(Input.GetKeyDown("" + 2) && item2Amount > 0)
        {
            slotSelected = 2;
        }
        else if (Input.GetKeyDown("" + 3) && item3Amount > 0)
        {
            slotSelected = 3;
        }
        else if (Input.GetKeyDown("" + 4) && item4Amount > 0)
        {
            slotSelected = 4;
        }
        else if (Input.GetKeyDown("" + 5) && item5Amount > 0)
        {
            slotSelected = 5;
        }
        
        if(slotSelected == 2)
        {
            item2.SetActive(true);
        }
        else
        { item2.SetActive(false); }

        if (slotSelected == 3 && item3Amount > 0)
        {
            item3.SetActive(true);
        }
        else
        { item3.SetActive(false); }

        if (slotSelected == 4 && item4Amount > 0)
        {
            item4.SetActive(true);
        }
        else
        { item4.SetActive(false); }

        if (slotSelected == 5 && item5Amount > 0)
        {
            item5.SetActive(true);
        }
        else
        { item5.SetActive(false); }

        if (player.GetComponent<Player>().left == true)
        {
            item2.GetComponent<SpriteRenderer>().flipX = false;
            item3.GetComponent<SpriteRenderer>().flipX = true;
            item3.transform.position = new Vector2(player.transform.position.x + 0.5f, player.transform.position.y);
            item4.GetComponent<SpriteRenderer>().flipX = false;
            item5.GetComponent<SpriteRenderer>().flipX = false;
        }
        if(player.GetComponent<Player>().right)
        {
            item2.GetComponent<SpriteRenderer>().flipX = true;
            item3.GetComponent<SpriteRenderer>().flipX = false;
            item4.GetComponent<SpriteRenderer>().flipX = true;
            item5.GetComponent<SpriteRenderer>().flipX = true;
        }
    }

}
