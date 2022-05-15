using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodeSub : MonoBehaviour
{

    private SpriteRenderer sr;
    public Sprite brokenSub;
    
    void OnTriggerEnter2D(Collider2D collider) 
    {
        // Debug.Log(collider.name);
        if (collider.name == "Sprite")
        {
            Debug.Log("Exploded");
            sr = collider.GetComponent<SpriteRenderer>();
            sr.sprite = brokenSub;
        }

    }
}
