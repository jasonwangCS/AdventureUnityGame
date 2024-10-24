using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public bool displayMenu = false;
    [SerializeField] GameObject menu;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(displayMenu)
        {
            menu.GetComponent<SpriteRenderer>().enabled = true;
            menu.SetActive(true);
        }
        else
        {
            menu.GetComponent<SpriteRenderer>().enabled = false;
            menu.SetActive(false);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        displayMenu = true;
        Debug.Log("DISPLAY");

    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        displayMenu = false;
    }
}
