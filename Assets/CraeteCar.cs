using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ButtonCreateCar : MonoBehaviour
{   
    [SerializeField] GameObject car;
    // Start is called before the first frame update
    void Start()
    {

        
    
        
        
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
    }

    
}
