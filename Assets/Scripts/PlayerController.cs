using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{


    private Vector2 move;
    public Rigidbody2D rb;
    public Animator anim;
    public SpriteRenderer sr;
    public Gradient gradient;

    private int speed;


    // Start is called before the first frame update
    void Start()
    {
        speed = 10;
    }

    // Update is called once per frame
    void Update()
    {

        if(Input.GetKeyDown(KeyCode.T))
        {
          Debug.Log("Testing");
        }

        Movement();

    }


    void Movement()
    {
        move.x = Input.GetAxisRaw("Horizontal");
        move.y = Input.GetAxisRaw("Vertical");

        if (move.x == 0 && move.y == 0)
        {
            // Debug.Log(1);
            // animator.SetBool("Fire", mooving);
            // anim.SetBool("Moving", false);
            foreach(AnimatorControllerParameter param in anim.parameters) {            
                anim.SetBool(param.name, false);            
            }
        }

        else
        {
            foreach(AnimatorControllerParameter param in anim.parameters) {            
                anim.SetBool(param.name, false);            
            }

            if (move.y == 0)
                anim.SetBool("Moving", true);
                // sprite
            
            // right
            if (move.x == 1)
            {
                // anim.Play("Sub_IdleR");
                anim.SetBool("Right", true);
                anim.SetBool("Left", false);
            }

            // left
            if (move.x == -1)
            {
                // anim.Play("Sub_IdleL");
                anim.SetBool("Left", true);
                anim.SetBool("Right", false);
            }

            // up
            if (move.y == 1)
            {
                anim.SetBool("Up", true);
                anim.SetBool("Down", false);
            }

            // down
            if (move.y == -1)
            {
                anim.SetBool("Down", true);
                anim.SetBool("Up", false);
            }
        }




        rb.MovePosition(rb.position + move.normalized * speed * Time.fixedDeltaTime);
    }


    void OnTriggerEnter2D(Collider2D collider) 
    {
        // Debug.Log(collider.name);
        if (collider.name == "Detector")
        {
            Debug.Log("Alert");
        }
        else if (collider.tag == "Cheese")
        {
            Debug.Log("Cheese found");
        }
        else if (collider.tag == "Mine")
        {
            StartCoroutine("CountDown", collider.gameObject);
            sr = collider.GetComponent<SpriteRenderer>();
            StartCoroutine("MineColor", sr);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Debug.Log(collision.name);
        if (collision.gameObject.tag == "Mine")
        {
            StopAllCoroutines();
            Debug.Log("Boom on collision");
            Destroy(collision.gameObject);
        }
    }

    IEnumerator CountDown(GameObject collider)
    {
        for(int i = 3; i > 0; i--)
        {
            Debug.Log(i);
            yield return new WaitForSeconds(1f);
        }
        Debug.Log("Boom by time");
        Destroy(collider);
    }

    IEnumerator MineColor(SpriteRenderer sr)
    {
        
        for(int i = 1; i <= 25; i++)
        {
            sr.color = gradient.Evaluate(i/30f);
            yield return new WaitForSeconds(0.1f);
        }
        // Debug.Log("Boom by time");
    }

}
