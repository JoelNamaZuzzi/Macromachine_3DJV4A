using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MainMenuScript : MonoBehaviour
{

    public AudioClip mainMenuMusic;
    public AudioClip theClick;
    public AudioSource Sauce;
    void Start()
    {
        if (SoundManager.Instance.musicPlay == true)
        {
            SoundManager.Instance.PlayMusic(mainMenuMusic, Sauce);
        }
    }
    public void PlaySolo()
    {
        
    }

    public void QuitApp()
    {
        Application.Quit();
    }
    
    public void btnMusic()
    {
        SoundManager.Instance.musicPlay = !SoundManager.Instance.musicPlay;
    }
    public void btnSound()
    {
        SoundManager.Instance.soundPlay = !SoundManager.Instance.soundPlay;
    }

    public void btnClick()
    {
        if (SoundManager.Instance.soundPlay == true)
        {
            AudioSource.PlayClipAtPoint(theClick, Sauce.transform.position);
        }
    }
}
