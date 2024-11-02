using UnityEngine;

public class CameraRotate : MonoBehaviour
{
    [SerializeField] private Transform target;           
    [SerializeField] private float distance = 5.0f;      
    [SerializeField] private float sensitivity = 5.0f;   
    [SerializeField] private float smoothTime = 0.1f;     

    [SerializeField] private float minVerticalAngle = -30.0f; 
    [SerializeField] private float maxVerticalAngle = 60.0f;  

    private float currentX = 0.0f;        
    private float currentY = 0.0f;        
    private Vector3 velocity = Vector3.zero; 

    void Start()
    {
        if (target == null)
        {
            Debug.LogError("Цель для камеры не назначена");
            return;
        }
        
        Vector3 angles = transform.eulerAngles;
        currentX = angles.y;
        currentY = angles.x;
    }

    void Update()
    {
        if (target == null) return;

        
        if (Input.GetMouseButton(1)) 
        {
            
            currentX += Input.GetAxis("Mouse X") * sensitivity;
            currentY -= Input.GetAxis("Mouse Y") * sensitivity;
            currentY = Mathf.Clamp(currentY, minVerticalAngle, maxVerticalAngle);
        }
    }

    void LateUpdate()
    {
        if (target == null) 
        return;
        Quaternion rotation = Quaternion.Euler(currentY, currentX, 0);
        Vector3 desiredPosition = target.position - (rotation * Vector3.forward * distance);

        transform.position = Vector3.SmoothDamp(transform.position, desiredPosition, ref velocity, smoothTime);
        transform.LookAt(target);
    }
}