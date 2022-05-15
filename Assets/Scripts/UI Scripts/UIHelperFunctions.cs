using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIHelperFunctions : MonoBehaviour
{
    public List<string> introMessages = new List<string>();
    public GameObject exitGameButton, playGameButton, storyMessagesText, headerBar, skipPrompt;

    private int _messageIndex = 0;
    private Text _storyMessageText;
    private bool _isIntroActive = false;

    private void Start()
    {
        _storyMessageText = storyMessagesText.GetComponentInChildren<Text>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && _isIntroActive)
            StartTheGame();
    }

    public void LoadScene(string scene_name)
    {
        SceneManager.LoadScene (scene_name);
    }

    public void ActiveTheStorytext()
    {
        playGameButton.SetActive(false);
        exitGameButton.SetActive(false);
        headerBar.SetActive(false);

        storyMessagesText.SetActive(true);
        skipPrompt.SetActive(true);

        _isIntroActive = true;

        SetUpTheIntroText();
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    private void SetUpTheIntroText()
    {
        _storyMessageText.text = introMessages[_messageIndex];

        InvokeRepeating(nameof(UpdateTheIntroText), 4.5f, 4.5f);
    }

    private void UpdateTheIntroText()
    {
        _messageIndex++;

        if (_messageIndex < introMessages.Count)
            _storyMessageText.text = introMessages[_messageIndex];

        if (_messageIndex == introMessages.Count)
            Invoke(nameof(StartTheGame), 3.0f);
    }

    private void StartTheGame()
    {
        SceneManager.LoadScene(1);
    }
}
