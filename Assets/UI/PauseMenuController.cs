using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class PauseMenuController : MonoBehaviour
{

    private UIDocument _doc;
    public GameObject UI_PauseMenu;
    public GameObject UI_MainMenu;
    private Button _resumeButton;
    private Button _settingsButton;
    private Button _quitButton;
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

        _resumeButton = _doc.rootVisualElement.Q<Button>("ResumeButton");
        _resumeButton.clicked += ResumeButtonOnClicked;

        _settingsButton = _doc.rootVisualElement.Q<Button>("SettingsButton");

        _quitButton = _doc.rootVisualElement.Q<Button>("QuitButton");
        _quitButton.clicked += QuitButtonOnClicked;

        _muteButton = _doc.rootVisualElement.Q<Button>("MuteButton");
        _muteButton.clicked += MuteButtonOnClicked;
    }

    private void PauseButtonClicked() 
    {
        UI_PauseMenu.SetActive(true);
        Time.timeScale = 0;
    }

    private void ResumeButtonOnClicked()
    {
        UI_PauseMenu.SetActive(false);
        Time.timeScale = 1;
    }

    private void QuitButtonOnClicked()
    {
        SceneManager.LoadScene("UI_MainMenu");
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
