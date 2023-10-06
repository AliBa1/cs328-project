using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class MainMenuController : MonoBehaviour
{

    private UIDocument _doc;
    private Button _playButton;
    private Button _settingsButton;
    private Button _exitButton;
    private Button _muteButton;

    [Header("Mute Button")]
    [SerializeField]
    private Sprite _mutedSprite;
    [SerializeField]
    private Sprite _unmutedSprite;
    private bool _muted;

    private void Awake()
    {
        _doc = GetComponent<UIDocument>();

        _playButton = _doc.rootVisualElement.Q<Button>("PlayButton");
        _playButton.clicked += PlayButtonOnClicked;

        _settingsButton = _doc.rootVisualElement.Q<Button>("SettingsButton");

        _exitButton = _doc.rootVisualElement.Q<Button>("ExitButton");
        _exitButton.clicked += ExitButtonOnClicked;

        _muteButton = _doc.rootVisualElement.Q<Button>("MuteButton");
        _muteButton.clicked += MuteButtonOnClicked;
    }

    private void PlayButtonOnClicked()
    {
        SceneManager.LoadScene("FirstLevel");
    }

    private void ExitButtonOnClicked()
    {
        Application.Quit();
    }

    private void MuteButtonOnClicked()
    {
        _muted = !_muted;
        var bg = _muteButton.style.backgroundImage;
        bg.value = Background.FromSprite(_muted ? _mutedSprite : _unmutedSprite);
        _muteButton.style.backgroundImage = bg;

        AudioListener.volume = _muted ? 0 : 1;
    }
}
