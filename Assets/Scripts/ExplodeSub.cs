using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodeSub : MonoBehaviour
{

    private SpriteRenderer sr;
    public Sprite brokenSub;

    private GameOverScript _gameOverScreenReference;

    public AudioClip lossClip;


    private void Start()
    {
        _gameOverScreenReference = FindObjectOfType<GameOverScript>();
    }

    void OnTriggerEnter2D(Collider2D collider) 
    {
        // Debug.Log(collider.name);
        if (collider.name == "Sprite")
        {
            Debug.Log("Exploded");
            sr = collider.GetComponent<SpriteRenderer>();
            sr.sprite = brokenSub;

            AudioSource audio = GameObject.Find("PlayerHolder").GetComponent<AudioSource>();
            audio.clip = lossClip;
            audio.Play();

            _gameOverScreenReference.EnableTheGameOverScreen();
        }

    }
}
