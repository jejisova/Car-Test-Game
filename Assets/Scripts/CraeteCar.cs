using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ButtonCreateCar : MonoBehaviour
{   
    [SerializeField] GameObject EvoX;
    [SerializeField] GameObject SilviaS15;
    GameObject car;
    
    void Start()
    {

       GameObject car =  Instantiate(EvoX,new Vector3(0,0,0),Quaternion.identity);       
        
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }

    void OnMouseOver()
    {   
        print("123");

        
    }

    public void CreateCar()
    {   
        Instantiate(car,new Vector3(0,0,0),Quaternion.identity);
        PlayerPrefs.SetInt("PlayerScore", 100);
        int score = PlayerPrefs.GetInt("PlayerScore");
    }

    
}
