using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class SpawnPoint : MonoBehaviour
{   
    [SerializeField] GameObject SilviaS15BlackRCC;
    [SerializeField] GameObject EvoXRedRCC;
    GameObject currentCar;
    
    void Start()
    {
       string carName = PlayerPrefs.GetString("SelectedCar");
       CheckCar(carName);
       CreateCar();
        
    }


    private void CheckCar(string carName)
    {
       switch (carName)
{
    case "SilviaS15BlackRCC":
    currentCar = SilviaS15BlackRCC;
        break;

    case "EvoXRedRCC":
    currentCar = EvoXRedRCC;
        break;
}
        
    }
    private void CreateCar()
    {
      Instantiate(currentCar,transform.position,transform.rotation);
        
    }


}
