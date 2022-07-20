using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MainMenuScript : MonoBehaviour
{
    public SoundObjectClass mainMenuSound;
    public AudioClip mainMenuMusic;
    public AudioClip theClick;
    public AudioSource Sauce;
    void Start()
    {
        if (SoundManager.Instance.musicPlay == true)
        {
            SoundManager.Instance.PlayMusic(mainMenuSound, Sauce);
        }
    }
    public void PlayScene(int SceneNumber)
    {
        SceneManager.LoadScene(SceneNumber, LoadSceneMode.Single);
    }

    public void QuitApp()
    {
        Application.Quit();
    }
    
    public void btnMusic()
    {
        SoundManager.Instance.musicPlay = !SoundManager.Instance.musicPlay;
        if (SoundManager.Instance.musicPlay == false)
        {
            SoundManager.Instance.StopMusic(Sauce);
        }else if (SoundManager.Instance.musicPlay == true)
        {
            SoundManager.Instance.PlayMusic(mainMenuSound,Sauce);
        }
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
