using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class CarCreator : MonoBehaviour
{

  [SerializeField] GameObject currentCar;
  [SerializeField] GameObject SilviaS15BlackRCC;
  [SerializeField] GameObject EvoXRedRCC;
  GameObject car;

  void Awake()
  {
    if (PlayerPrefs.GetString("SelectedCar") != null)
    { CheckCar(PlayerPrefs.GetString("SelectedCar")); }
    CreateCar(currentCar);
    SendObjectToMainCamera();
  }

  public void CreateCar(GameObject selectedCar)
  {
    if (car)
    { Destroy(car); }

    car = Instantiate(selectedCar, transform.position, transform.rotation);
    RCC_CarControllerV3 carRigidbody = car.GetComponent<RCC_CarControllerV3>();
    carRigidbody.SetCanControl(false);

    SendObjectToMainCamera();
    PlayerPrefs.SetString("SelectedCar", selectedCar.name);
  }


  void SendObjectToMainCamera()
  {
    var cameraRotate = FindAnyObjectByType<CameraRotate>();
    cameraRotate.SetTarget(car);
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
}



