using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GarageData
{
    
    public float[,] CarColors;
    public String[] name;
    public String selectedCarName = "Tuture1";
    public String[] modelName;

    public GarageData(GarageUIScript garage)
    {
        CarColors = new float[3,3];
        name = new string[3];
        modelName = new string[3];

        CarColors[0,0] = garage.cars[0].GetComponent<DissolutionScript>().CarColor.r;
        CarColors[1,0] = garage.cars[0].GetComponent<DissolutionScript>().CarColor.g;
        CarColors[2,0] = garage.cars[0].GetComponent<DissolutionScript>().CarColor.b;
        
        CarColors[0,1] = garage.cars[1].GetComponent<DissolutionScript>().CarColor.r;
        CarColors[1,1] = garage.cars[1].GetComponent<DissolutionScript>().CarColor.g;
        CarColors[2,1] = garage.cars[1].GetComponent<DissolutionScript>().CarColor.b;
        
        CarColors[0,2] = garage.cars[2].GetComponent<DissolutionScript>().CarColor.r;
        CarColors[1,2] = garage.cars[2].GetComponent<DissolutionScript>().CarColor.g;
        CarColors[2,2] = garage.cars[2].GetComponent<DissolutionScript>().CarColor.b;

        //CarColor = garage.cars[0].GetComponent<MeshRenderer>().material.color;
        name[0] = garage.cars[0].name;
        name[1] = garage.cars[1].name;
        name[2] = garage.cars[2].name;
        
        selectedCarName = garage.selectedCar.name;
        
        for (int i = 0; i < 3; i++)
        {
            if (garage.cars[i].transform.Find(garage.modelCars[0].gameObject.name).gameObject.activeSelf)
            {
                modelName[i] = garage.modelCars[0].gameObject.name;
                
            }

            if (garage.cars[i].transform.Find(garage.modelCars[1].gameObject.name).gameObject.activeSelf)
            {
                modelName[i] = garage.modelCars[1].gameObject.name;
                
            }

            if (garage.cars[i].transform.Find(garage.modelCars[2].gameObject.name).gameObject.activeSelf)
            {
                modelName[i] = garage.modelCars[2].gameObject.name;
            }
        }
    }
}
