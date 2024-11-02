using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class CarCreator : MonoBehaviour
{   
    [SerializeField] GameObject EvoX;
    GameObject car;
    
    void Awake()
    {  
       CreateCar(EvoX);
       SendObjectToCamera();
    }
    
    public void CreateCar(GameObject selectedCar)
    { 
      if(car)
      {Destroy(car);}

      car =  Instantiate(selectedCar,transform.position,transform.rotation);
      SendObjectToCamera();
      PlayerPrefs.SetString("SelectedCar", selectedCar.name);
    }
    

    void SendObjectToCamera()
    {
        var cameraRotate = FindAnyObjectByType<CameraRotate>();
        cameraRotate.SetTarget(car);
    }

    
}
