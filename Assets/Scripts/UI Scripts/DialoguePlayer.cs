using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialoguePlayer : MonoBehaviour
{
    public DialogueData curDialogueData;
    public Text dialogueText;
    public Image dialogueActor;
    public GameObject dialogueWindow;
    public Button dialogueButton;

    private int _dialogueDataLength;
    private int _curDialogueLine;
    private PlayerController _playerReference;
    private Text _buttonText;

    public bool isDialogueEnabled;


    private void Awake()
    {
        _playerReference = FindObjectOfType<PlayerController>();
        _buttonText = dialogueButton.GetComponentInChildren<Text>();
    }

    // Start is called before the first frame update
    void Start()
    {
        InitializeDialogue();

    }

    private Sprite GetDialoguePortrait(int actorIndex)
    {
        Sprite actorSprite = dialogueActor.sprite;

        switch (actorIndex)
        {
            case 0:
                actorSprite = Resources.Load<Sprite>("Sprites/Characters/Main Character");
                break;
            case 1:
                actorSprite = Resources.Load<Sprite>("Sprites/Characters/Villain");
                break;
            default:
                break;
        }

        return actorSprite;
    }

    public void InitializeDialogue()
    {
        _dialogueDataLength = curDialogueData.dialogueLines.Length;
        dialogueText.text = curDialogueData.dialogueLines[0];
        dialogueActor.sprite = GetDialoguePortrait(curDialogueData.actorsIndices[0]);
        dialogueButton.onClick.AddListener(() => NextDialogueLine());
        dialogueWindow.SetActive(true);
        _playerReference._isPlayerBusy = true;
        _buttonText.text = "Next!";
    }

    public void NextDialogueLine()
    {
        _curDialogueLine++;

        if (_curDialogueLine < _dialogueDataLength)
        {
            dialogueText.text = curDialogueData.dialogueLines[_curDialogueLine];
            dialogueActor.sprite = GetDialoguePortrait(curDialogueData.actorsIndices[_curDialogueLine]);

            if (_curDialogueLine == _dialogueDataLength - 1)
                _buttonText.text = "Go!";
        }
        else
        {
            dialogueWindow.SetActive(false);
            _curDialogueLine = 0;
            _playerReference._isPlayerBusy = false;
        }
    }
}
