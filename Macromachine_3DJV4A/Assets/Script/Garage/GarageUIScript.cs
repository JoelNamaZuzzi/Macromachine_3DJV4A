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
    public GameObject selectedCar;
    public bool carModif;

    public GameObject[] cars;
    public GameObject[] modelCars;
    private int counter = 0;
    private void Start()
    {
        SoundManager.Instance.PlayMusic(zique, ZiqueSauce);
        cars = new GameObject[3];
        cars[0] = GameObject.Find("Tuture1").gameObject;
        cars[1] = GameObject.Find("Tuture2").gameObject;
        cars[2] = GameObject.Find("Tuture3").gameObject;
        btnLoadGarage();
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
            
            if (selectedCar.transform.Find(modelCars[0].gameObject.name).gameObject.activeSelf)
            {
                counter = 0;
                Debug.LogError(counter);
            }
            if (selectedCar.transform.Find(modelCars[1].gameObject.name).gameObject.activeSelf)
            {
                counter = 1;
                Debug.LogError(counter);
            }
            if (selectedCar.transform.Find(modelCars[2].gameObject.name).gameObject.activeSelf)
            {
                counter = 2;
                Debug.LogError(counter);
            }
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
        //selectedCar.GetComponent<MeshRenderer>().material = mat;
        selectedCar.GetComponent<DissolutionScript>().CarColor = mat.color;
        selectedCar.GetComponent<DissolutionScript>().ResetColor();
    }

    public void btnNextCar()
    {
        selectedCar.transform.Find(modelCars[counter].gameObject.name).gameObject.SetActive(false);
        counter++;
        if (counter > modelCars.Length -1)
        {
            counter = 0;
        }
        selectedCar.transform.Find(modelCars[counter].gameObject.name).gameObject.SetActive(true);
        //Debug.Log("NextCar");
        
    }
    
    public void btnPreviousCar()
    {
        selectedCar.transform.Find(modelCars[counter].gameObject.name).gameObject.SetActive(false);
        counter--;
        if (counter < 0)
        {
            counter = modelCars.Length - 1;
        }
        selectedCar.transform.Find(modelCars[counter].gameObject.name).gameObject.SetActive(true);

        //Debug.Log("PreviousCar");
    }
    
    public void btnSaveGarage()
    {
        SaveSystemGarage.SaveGarage(this);
    }
    
    public void btnLoadGarage()
    {
        GarageData data = SaveSystemGarage.LoadGarage(this);

        cars[0].GetComponent<DissolutionScript>().CarColor = new Color(data.CarColors[0,0],data.CarColors[1,0],data.CarColors[2,0]);
        cars[0].GetComponent<DissolutionScript>().ResetColor();
        
        cars[1].GetComponent<DissolutionScript>().CarColor = new Color(data.CarColors[0,1],data.CarColors[1,1],data.CarColors[2,1]);
        cars[1].GetComponent<DissolutionScript>().ResetColor();
        
        cars[2].GetComponent<DissolutionScript>().CarColor = new Color(data.CarColors[0,2],data.CarColors[1,2],data.CarColors[2,2]);
        cars[2].GetComponent<DissolutionScript>().ResetColor();
        
        cars[0].name = data.name[0];
        cars[1].name = data.name[1];
        cars[2].name = data.name[2];
        
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                cars[i].transform.Find(data.modelName[j]).gameObject.SetActive(false);
            }
        }

        for (int k = 0; k < 3; k++)
        {
            cars[k].transform.Find(data.modelName[k]).gameObject.SetActive(true);
        }
    }
}
