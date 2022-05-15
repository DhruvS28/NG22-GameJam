using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverScript : MonoBehaviour
{
    private Button _restartButton;
    private Scene _curScene;
    public List<GameObject> _childrenObjects;

    private PlayerController _playerReference;


    // Start is called before the first frame update
    void Start()
    {
        _restartButton = GetComponentInChildren<Button>();

        _playerReference = FindObjectOfType<PlayerController>();

        _curScene = SceneManager.GetActiveScene();

        DisableChidlrenOnstart();
    }

    private void DisableChidlrenOnstart()
    {
        foreach (GameObject gameobject in _childrenObjects)
            gameobject.SetActive(false);
    }

    public void EnableChildrenOnFail()
    {
        foreach (GameObject gameobject in _childrenObjects)
            gameobject.SetActive(true);
    }

    public void RestartTheLevel()
    {
        SceneManager.LoadScene(_curScene.name);
    }

    public void EnableTheGameOverScreen()
    {
        _playerReference._isPlayerBusy = true;
        Invoke(nameof(EnableChildrenOnFail), 2.0f);
    }
}
