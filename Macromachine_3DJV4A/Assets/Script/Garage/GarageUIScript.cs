using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GarageUIScript : MonoBehaviour
{
    public GameObject Cam;
    public AudioSource ZiqueSauce;
    public AudioSource SoundSauce;
    public SoundObjectClass zique;
    public SoundObjectClass btnSound;
    private GameObject selectedCar;
    private bool carModif;

    private void Start()
    {
        SoundManager.Instance.PlayMusic(zique, ZiqueSauce);
    }

    public void btnPosBool(bool isMain)
    {
        if (isMain == true)
        {
            carModif = true;
        }
        else
        {
            carModif = false;
        }
    }

    public void btnPosCar(GameObject Car = null)
    {
        if (carModif == true)
        {
            selectedCar = Car;
            Debug.Log(selectedCar.name);
        }
    }
    
    public void btnPos(Transform camPos)
    {
        Cam.transform.position = camPos.position;
        Cam.transform.rotation = camPos.rotation;
    }
    
    public void btnClick()
    {
        SoundManager.Instance.PlaySoundEffect(btnSound, SoundSauce);
    }
    
    public void backMenu(int SceneNumber)
    {
        SceneManager.LoadScene(SceneNumber, LoadSceneMode.Single);
    }
    
    //Color changes
    public void btnColor(Material mat)
    {
        selectedCar.GetComponent<MeshRenderer>().material = mat;
    }
}
