using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class NPC : MonoBehaviour
{
    [SerializeField] GameObject message;
    [SerializeField] UnityEngine.UI.Text messageText;
    public bool displayMessage = false;
    // Start is called before the first frame update

   
    void Start()
    {
        if (gameObject.name.Equals("npc1"))
        {
            messageText = GameObject.Find("npc1Text").GetComponent<UnityEngine.UI.Text>();
        }
        else
            messageText = GameObject.Find("npc2Text").GetComponent<UnityEngine.UI.Text>();


    }

    // Update is called once per frame
    void Update()
    {
        if (displayMessage)
        {
            message.GetComponent<SpriteRenderer>().enabled = true;
            message.SetActive(true);
            if (messageText.name.Equals("npc1Text"))
            {
                messageText.text = "daniel's game is\r\n     worse";
            }
            else
                messageText.text = "i like to eat little\r\n     boys";
            
        }
        else
        {
            message.GetComponent<SpriteRenderer>().enabled = false;
            message.SetActive(false);
            messageText.text = "";
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        displayMessage = true;
        Debug.Log("DISPLAY");

    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        displayMessage = false;
    }
}
