using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class MenuHandler : MonoBehaviour
{

    public AudioMixer masterAudio;
    public float startAudio;
    // Start is called before the first frame update
    void Start()
    {
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


}
