using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Zombie : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Transform player;
    public Vector2 target;
    public float speed = 10f;
    void Start()
    {
        player = GameObject.Find("player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        target = player.transform.position;

        //move this object towards the player
        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        speed = 0f;
        //attack every x seconds and play attack animation
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        speed = 10f;
    }
}
