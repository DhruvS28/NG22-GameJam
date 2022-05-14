using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{


    private Vector2 move;
    public Rigidbody2D rb;

    private int speed;


    // Start is called before the first frame update
    void Start()
    {
        speed = 5;
    }

    // Update is called once per frame
    void Update()
    {

        if(Input.GetKeyDown(KeyCode.T))
        {
          Debug.Log("Testing");
        }


        move.y = Input.GetAxisRaw("Vertical");
        move.x = Input.GetAxisRaw("Horizontal");

        rb.MovePosition(rb.position + move.normalized * speed * Time.fixedDeltaTime);

    }


    void OnTriggerEnter2D(Collider2D collider) 
    {
        Debug.Log(collider);
        StartCoroutine("CountDown");
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision);
        StopAllCoroutines();
        Debug.Log("Boom on collision");
    }

    IEnumerator CountDown()
    {
        for(int i = 3; i > 0; i--)
        {
            Debug.Log(i);
            yield return new WaitForSeconds(1f);
        }

        Debug.Log("Boom by time");
    }


}
