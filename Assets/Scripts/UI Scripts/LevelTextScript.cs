using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelTextScript : MonoBehaviour
{
    private Text _levelText;
    private Scene _curScene;

    // Start is called before the first frame update

    private void Awake()
    {
        _levelText = GetComponentInChildren<Text>();
        _curScene = SceneManager.GetActiveScene();
    }
    void Start()
    {
        _levelText.text = "Level: " + _curScene.name;
    }


}
