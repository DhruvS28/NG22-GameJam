using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIUpdater : MonoBehaviour
{   
    // part 2
    [SerializeField]
    private Text score_t;

    // part 3
    [SerializeField]
    private Text health_t;

    // part 4
    [ SerializeField ]
    private GameObject heart_prefab;
    private List<GameObject> hearts;

    [ SerializeField ]
    private GameObject grid_layout ;


    // Start is called before the first frame update
    void Start()
    {
        // part 4
        hearts = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateScore(int new_score) 
    {   
        // part 2
        score_t.text = "Current score: " + new_score;
    }

    public void UpdateHealth(int new_health) 
    {   
        // part 3
        health_t.text = "Current Health: " + new_health;

        // part 4
        int num_hearts = hearts.Count;
        int heart_diff = new_health - num_hearts;

        if (heart_diff > 0)
        {
            for (int i=0; i < heart_diff; i++)
            {
                GameObject new_heart = Instantiate(heart_prefab);
                new_heart.transform.SetParent(grid_layout.transform, false);
                hearts.Add(new_heart);
            }
        }
        else if (heart_diff < 0)
        {
            for (int i=0; i < Mathf.Abs(heart_diff); i++)
            {
                GameObject to_remove = hearts[hearts.Count - 1];
                hearts.Remove(to_remove);
                Destroy(to_remove);
            }
        }


    }
}
