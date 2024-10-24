using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyItem : MonoBehaviour
{
    // Start is called before the first frame update
    //[SerializeField] GameObject item;
    [SerializeField] GameObject manager;
    [SerializeField] int itemSlotNumber;
    [SerializeField] int price;
    void Start()
    {
        manager = GameObject.FindGameObjectsWithTag("manager")[0];
    }
    private void OnMouseDown()
    {
        Debug.Log("buy item");
        int tmpCoins = manager.GetComponent<Manager>().coins;
        if (itemSlotNumber == 2)
        {
            if(tmpCoins - price >= 0 && manager.GetComponent<Manager>().item2Amount == 0)
            {
                manager.GetComponent<Manager>().item2Amount++;
                manager.GetComponent<Manager>().coins -= price;
            }
        }
        if (itemSlotNumber == 3)
        {
            if (tmpCoins - price >= 0)
            {
                manager.GetComponent<Manager>().item3Amount++;
                manager.GetComponent<Manager>().coins -= price;
            }
        }
        if (itemSlotNumber == 4)
        {
            if (tmpCoins - price >= 0)
            {
                manager.GetComponent<Manager>().item4Amount++;
                manager.GetComponent<Manager>().coins -= price;
            }
        }
        if (itemSlotNumber == 5)
        {
            if (tmpCoins - price >= 0)
            {
                manager.GetComponent<Manager>().item5Amount++;
                manager.GetComponent<Manager>().coins -= price;
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
