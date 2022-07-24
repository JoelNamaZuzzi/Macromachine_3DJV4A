using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using Mirror;

public class MainMenuScript : MonoBehaviour
{
    public SoundObjectClass mainMenuSound;
    public SoundObjectClass clickMenuSound;
    public AudioSource ziqueSauce;
    public AudioSource soundSauce;
    void Start()
    { 
        SoundManager.Instance.PlayMusic(mainMenuSound, ziqueSauce);
    }
    public void PlayScene(int sceneNumber)
    {
        SceneManager.LoadScene(sceneNumber, LoadSceneMode.Single);
    }

    public void QuitApp()
    {
        Application.Quit();
    }
    
    public void BtnMusic()
    {
        SoundManager.Instance.musicPlay = !SoundManager.Instance.musicPlay;
        if (SoundManager.Instance.musicPlay == false)
        {
            SoundManager.Instance.StopMusic(ziqueSauce);
        }else if (SoundManager.Instance.musicPlay)
        {
            SoundManager.Instance.PlayMusic(mainMenuSound,ziqueSauce);
        }
    }
    public void BtnSound()
    {
        SoundManager.Instance.soundPlay = !SoundManager.Instance.soundPlay;
    }

    public void BtnClick()
    {
        SoundManager.Instance.PlaySoundEffect(clickMenuSound,soundSauce);
    }

    public void HostLobby()
    {
        NetworkManager.singleton.StartHost();
    }

    public void ChangeZiqueValue(float val)
    {
        SoundManager.Instance.musicVolume = val;
        ziqueSauce.volume = mainMenuSound.priority * val;
    }

    public void ChangeSoundValue(float val)
    {
        SoundManager.Instance.soundVolume = val;
        ziqueSauce.volume = clickMenuSound.priority * val;
    }
    
}
