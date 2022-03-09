using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GarageUIScript : MonoBehaviour
{
    public GameObject Cam;
    public AudioClip theClick;
    public AudioSource Sauce;
    private GameObject selectedCar;
    private bool carModif;

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
        if (SoundManager.Instance.soundPlay == true)
        {
            AudioSource.PlayClipAtPoint(theClick, Sauce.transform.position);
        }
    }
    
    public void backMenu(int SceneNumber)
    {
        SceneManager.LoadScene(SceneNumber, LoadSceneMode.Single);
    }
}
