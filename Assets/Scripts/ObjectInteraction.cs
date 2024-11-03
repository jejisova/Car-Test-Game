using System;
using UnityEngine;

public class ObjectInteraction : MonoBehaviour
{   
    Vector3 startPosition;
    [SerializeField] float moveSpead;
    [SerializeField] Vector3 vectorToMove;
    [SerializeField] AudioClip point;
    void Start()
    {
        startPosition = transform.position;        
    }
    private void OnTriggerEnter()
    {   
        AudioSource.PlayClipAtPoint(point,transform.position);
        Destroy(gameObject); 
    }

    void Update()
    {
        MoveObject();
    }

    private void MoveObject()
    {
        var moveProgress = Mathf.PingPong(moveSpead*Time.time, 1);
        Vector3 offset = vectorToMove * moveProgress;
        transform.position = startPosition + offset; 
    }
}