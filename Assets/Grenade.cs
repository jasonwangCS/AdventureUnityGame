using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour
{
    // Start is called before the first frame update
    Animator animator;
    [SerializeField] GameObject manager;
    void Start()
    {
        manager = GameObject.FindGameObjectsWithTag("manager")[0];
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyUp(KeyCode.Space) && manager.GetComponent<Manager>().slotSelected == 3 && manager.GetComponent<Manager>().item3Amount > 0)
        {
            GetComponent<Animator>().Play("Explosion", -1, 0f);
            manager.GetComponent<Manager>().item3Amount--;
        }
    }
}
