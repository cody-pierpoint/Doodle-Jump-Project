using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.UI;

public class MenuHandler : MonoBehaviour
{

    public AudioMixer masterAudio;
    public float startAudio;
    public float sfxAudio;
    public float musicAudio;
  //  public GameObject MainMenu;
    public AudioSource GameMusic;
    public Slider masterSlider;
    public Slider sfxSlider;
    public Slider musicSlider;
    public bool isPaused;
    public GameObject pausePanel;
    public GameObject optionsPanel;

    //public float volume;
    private bool IsPaused
    {
        get
        {
            return isPaused; 
        }
        set
        {
            Time.timeScale = value ? 1 : 0;
            pausePanel.SetActive(value);
        }
       
    }

    // Start is called before the first frame update
    void Start()
    {
        //play game music
        GameMusic.Play();
        //set volume to saved player prefs get the saved values;
        masterAudio.SetFloat("MasterVolume", PlayerPrefs.GetFloat("MasterVolume"));
        masterAudio.SetFloat("MusicVolume", PlayerPrefs.GetFloat("MusicVolume"));
        masterAudio.SetFloat("SFXVolume", PlayerPrefs.GetFloat("SFXVolume"));
        // ChangeVolume(startAudio);
        //get the starting saved playerprefs values for volume
        startAudio = PlayerPrefs.GetFloat("MasterVolume");
        sfxAudio = PlayerPrefs.GetFloat("SFXVolume");
        // ChangeSFX(sfxAudio);

        musicAudio = PlayerPrefs.GetFloat("MusicVolume");
      //  ChangeMusic(musicAudio);
      //set slider value to = saved volume
        masterSlider.value = startAudio;
        sfxSlider.value = sfxAudio;
        musicSlider.value = musicAudio;
    }

    // Update is called once per frame
    void Update()
    {
        //if escape is press and game is not paused and options panel is not open 
        if (Input.GetKeyDown(KeyCode.Escape) && !IsPaused && optionsPanel.activeSelf == false)
        {
            //pause game
            pauseGame();
        }
       
        //if (Input.GetKeyDown(KeyCode.Escape))
        //    isPaused = true;


        // PlayerPrefs.SetFloat("Volume", volume);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void loadGame(int scene)
    {
        SceneManager.LoadScene(scene);
        Time.timeScale = 1;
    }

    public void ChangeVolume(float volume)
    {
        //when volume is changed save volume the set volume to be the new saved volume
        masterAudio.SetFloat("MasterVolume", volume);
        
        
        PlayerPrefs.SetFloat("MasterVolume", volume);
       
        PlayerPrefs.Save();
        // masterAudio = PlayerPrefs.GetFloat("MusicVolume");
        // GameMusic = PlayerPrefs.GetFloat("MusicVolume", volume)
    }

    public void ChangeSFX(float volume)
    {
        //when volume is changed save volume the set volume to be the new saved volume
        masterAudio.SetFloat("SFXVolume", volume);
        PlayerPrefs.SetFloat("SFXVolume", volume);
        PlayerPrefs.Save();
    }
    public void ChangeMusic(float volume)
    {
        //when volume is changed save volume the set volume to be the new saved volume
        masterAudio.SetFloat("MusicVolume", volume);
        PlayerPrefs.SetFloat("MusicVolume", volume);
        PlayerPrefs.Save();
    }
    public void UnPause()
    {
        //unpause game
        isPaused = false;
        Time.timeScale = 1;
        pausePanel.SetActive(false);
    }
    private void pauseGame()
    { 
        //pause game
            IsPaused = true;
            Time.timeScale = 0;
            pausePanel.SetActive(true);
        
       
    }
    public void MuteGame(bool isMuted)
    {
        //mute toggle
        if (isMuted)
        {
            masterAudio.SetFloat("MasterVolume", -80);

        }
        else
        {
            masterAudio.SetFloat("MasterVolume", 0);
        }
    }
    public void FullScreen(bool isFullScreen)
    {
        //fullscreen toggle
        Screen.fullScreen = isFullScreen;
    }
}
