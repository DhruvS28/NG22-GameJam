using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIAlarmScript : MonoBehaviour
{
    private Image _childImage;
    private Text _childText;
    private PlayerController _playerReference;

    private Color _baseGrey = new Color(0.3f, 0.3f, 0.3f);

    // Start is called before the first frame update
    void Start()
    {
        _playerReference = FindObjectOfType<PlayerController>();

        _childImage = GetComponentInChildren<Image>();
        _childText = GetComponentInChildren<Text>();
    }

    private void LateUpdate()
    {
        ChangeColorOnProximity();
    }

    public void ChangeColorOnProximity()
    {
        if (_playerReference._isMineNearby)
        {
            _childImage.color = new Color(0.5f, 0.04f, 0.04f);
            _childText.color = new Color(1f, 1f, 1f);
        }
        else if (!_playerReference._isMineNearby)
        {
            _childImage.color = _baseGrey;
            _childText.color = _baseGrey;
        }
    }
}

