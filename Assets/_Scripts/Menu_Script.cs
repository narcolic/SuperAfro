using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu_Script : MonoBehaviour
{
    public Slider[] volumeSliders;

    public Canvas exitMenu;
    public Canvas mainMenu;
    public Canvas settingsMenu;
    public Button startButton;
    public Button settingsButton;
    public Button exitButton;

    // Use this for initialization
    void Start()
    {
        volumeSliders[0].value = AudioManager.instance.masterVolumePercent;
        volumeSliders[1].value = AudioManager.instance.musicVolumePercent;
        volumeSliders[2].value = AudioManager.instance.sfxVolumePercent;

        exitMenu = exitMenu.GetComponent<Canvas>();
        mainMenu = mainMenu.GetComponent<Canvas>();
        settingsMenu = settingsMenu.GetComponent<Canvas>();

        startButton = startButton.GetComponent<Button>();
        exitButton = exitButton.GetComponent<Button>();
        settingsButton = settingsButton.GetComponent<Button>();

        exitMenu.enabled = false;
        settingsMenu.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void exitPress()
    {
        exitMenu.enabled = true;
        mainMenu.enabled = false;
        startButton.enabled = false;
        exitButton.enabled = false;
        settingsButton.enabled = false;
        settingsMenu.enabled = false;
    }

    public void noPress()
    {
        exitMenu.enabled = false;
        mainMenu.enabled = true;
        startButton.enabled = true;
        exitButton.enabled = true;
        settingsButton.enabled = true;
        settingsMenu.enabled = false;
    }

    public void backPress()
    {
        exitMenu.enabled = false;
        mainMenu.enabled = true;
        startButton.enabled = true;
        exitButton.enabled = true;
        settingsButton.enabled = true;
        settingsMenu.enabled = false;
    }



    public void startButtonAction()
    {
        SceneManager.LoadScene("Game");
    }

    public void exitButtonAction()
    {
        Application.Quit();
    }

    public void settingsButtonAction()
    {
        exitMenu.enabled = false;
        mainMenu.enabled = false;
        startButton.enabled = false;
        exitButton.enabled = false;
        settingsButton.enabled = false;
        settingsMenu.enabled = true;
    }

    public void SetMasterVolume(float value)
    {
        AudioManager.instance.SetVolume(value, AudioManager.AudioChannel.Master);
    }
    public void SetMusicVolume(float value)
    {
        AudioManager.instance.SetVolume(value, AudioManager.AudioChannel.Music);
    }
    public void SetSfxVolume(float value)
    {
        AudioManager.instance.SetVolume(value, AudioManager.AudioChannel.Sfx);
    }
}
