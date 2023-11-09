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
    [Header("Levels")]
    [SerializeField]
    private VisualTreeAsset _levelsButtonsTemplate;
    private VisualElement _levelsButtons;
    private VisualElement _buttonsWrapper;

    private void Awake()
    {
        _doc = GetComponent<UIDocument>();

        _playButton = _doc.rootVisualElement.Q<Button>("PlayButton");
        _playButton.clicked += PlayButtonOnClicked;

        _levelsButtons = _levelsButtonsTemplate.CloneTree();
        var level1Button = _levelsButtons.Q<Button>("Level1Button");
        level1Button.clicked += Level1ButtonOnClicked;
        var level2Button = _levelsButtons.Q<Button>("Level2Button");
        level2Button.clicked += Level2ButtonOnClicked;
        var level3Button = _levelsButtons.Q<Button>("Level3Button");
        level3Button.clicked += Level3ButtonOnClicked;
        var backButton = _levelsButtons.Q<Button>("BackButton");
        backButton.clicked += BackButtonOnClicked;

        //_levelsButtons = _doc.rootVisualElement.Q<Button>("SettingsButton");
        _buttonsWrapper = _doc.rootVisualElement.Q<VisualElement>("Buttons");

        _settingsButton = _doc.rootVisualElement.Q<Button>("SettingsButton");

        _exitButton = _doc.rootVisualElement.Q<Button>("ExitButton");
        _exitButton.clicked += ExitButtonOnClicked;

        _muteButton = _doc.rootVisualElement.Q<Button>("MuteButton");
        _muteButton.clicked += MuteButtonOnClicked;
    }

    private void PlayButtonOnClicked()
    {
        _buttonsWrapper.Clear();
        _buttonsWrapper.Add(_levelsButtons);
        
    }

    private void Level1ButtonOnClicked()
    {
        SceneManager.LoadScene("FirstLevel");
    }

    private void Level2ButtonOnClicked()
    {
        SceneManager.LoadScene("SecondLevel");
    }

    private void Level3ButtonOnClicked()
    {
        SceneManager.LoadScene("ThirdLevel");
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

    private void BackButtonOnClicked()
    {
        _buttonsWrapper.Clear();
        _buttonsWrapper.Add(_playButton);
        _buttonsWrapper.Add(_settingsButton);
        _buttonsWrapper.Add(_exitButton);
    }
}
