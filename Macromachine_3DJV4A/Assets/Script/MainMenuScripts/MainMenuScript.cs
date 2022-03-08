using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MainMenuScript : MonoBehaviour
{

    
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
}
