using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CarCreator : MonoBehaviour
{   
    [SerializeField] GameObject EvoX;
    [SerializeField] GameObject SilviaS15;
    GameObject car;

    [SerializeField] GameObject floor;
    
    void Awake()
    {  
       CreartEvoX();
       SendObjectToCamera();
    }

    public void CreartEvoX()
    { 
      Destroy(car);
      car =  Instantiate(EvoX,transform.position,transform.rotation);
      SendObjectToCamera();
       
       PlayerPrefs.SetInt("PlayerScore", 100);
       int score = PlayerPrefs.GetInt("PlayerScore");

    }

    public void CreateSilviaS15()
    { 
      Destroy(car);
      car =  Instantiate(SilviaS15,transform.position,transform.rotation);
      SendObjectToCamera();
      PlayerPrefs.SetInt("PlayerScore", 100);
      int score = PlayerPrefs.GetInt("PlayerScore");
    }


    void SendObjectToCamera()
    {
        var cameraRotate = FindAnyObjectByType<CameraRotate>();
        cameraRotate.SetTarget(car);
    }

    
}
