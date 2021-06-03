using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class MenuHandler : MonoBehaviour
{

    public AudioMixer masterAudio;
    public float startAudio;
    public GameObject MainMenu;
    public AudioSource GameMusic;

    // Start is called before the first frame update
    void Start()
    {
        GameMusic.Play();
        startAudio = PlayerPrefs.GetFloat("Volume");
    }

    // Update is called once per frame
    void Update()
    {
        
        //PlayerPrefs.SetFloat("Volume", volume);
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
        masterAudio.SetFloat("MusicVolume", volume);
       // GameMusic = PlayerPrefs.GetFloat("MusicVolume", volume);


     
    }

}
