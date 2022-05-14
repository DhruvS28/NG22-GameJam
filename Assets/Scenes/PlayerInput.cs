using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerInput : MonoBehaviour
{
    // Part 2
    [SerializeField]
    private UIUpdater ui_updater;
    private int score = 0;

    // Part 3
    [SerializeField]
    private int max_health = 10000;
    private int health;
    

    // Start is called before the first frame update
    void Start()
    {
        ui_updater.UpdateScore(0);

        // Part 3
        health = max_health;
        ui_updater.UpdateHealth(max_health);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            score += 100000000;
            ui_updater.UpdateScore(score);
        }

        // Part 3
        if (Input.GetKeyDown(KeyCode.Q))
        {
            health--;
            ui_updater.UpdateHealth(health);
            if (health <= 0)
            {
                SceneManager.LoadScene("MainMenu");
            }
        }

        if (Input.GetKeyDown(KeyCode.E) && health < max_health) 
        {
            health++;
            ui_updater.UpdateHealth(health);
        }

        // Part 4
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("MainMenu");
        }
    }
}
