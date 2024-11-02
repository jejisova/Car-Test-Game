using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FinishGame : MonoBehaviour
{  GameObject finishMenu;

   void Start()
   {
    finishMenu = GameObject.Find("Finish_Menu");
    finishMenu.SetActive(false);


   }
   void OnTriggerEnter()
   {
    HideRCCMenu(); 
    ShowFinishMenu();

   }

    private void HideRCCMenu()
    {
        GameObject rccmenu = GameObject.Find("RCCCanvas");
        rccmenu.SetActive(false);
        RCC_CarControllerV3 rccCar = FindAnyObjectByType<RCC_CarControllerV3>();
        rccCar.gameObject.SetActive(false);
        
        

    }

    private void ShowFinishMenu()
    {   
        
        finishMenu.SetActive(true);
    }
}
