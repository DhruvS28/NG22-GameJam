using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CheeseFoundScript : MonoBehaviour
{
    public GameObject cheeseFoundWindow;

    private PlayerController _playerControllerReference;

    private Scene _curScene;

    public AudioClip VictoryClip;


    // Start is called before the first frame update
    void Start()
    {
        cheeseFoundWindow.SetActive(false);

        _playerControllerReference = FindObjectOfType<PlayerController>();

        _curScene = SceneManager.GetActiveScene();
    }

    public void TurnOnTheCheeseWindow()
    {
            AudioSource audio = GameObject.Find("PlayerHolder").GetComponent<AudioSource>();
            audio.clip = VictoryClip;
            audio.Play();

            cheeseFoundWindow.SetActive(true);
            _playerControllerReference._isPlayerBusy = true;
    }

    public void GoToNextLevel()
    {
        SceneManager.LoadScene(_curScene.buildIndex + 1);
    }

    public void LoadTheMenuScene()
    {
        SceneManager.LoadScene(0);
    }
}
