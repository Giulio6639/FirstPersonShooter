using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float mouseSensibility = 100f;

    public Transform playerBody;
    float xRotation;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; // il cursore è bloccato al centro dello schermo
    }

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensibility * Time.deltaTime; // valore di rotazione sull'asse X prese dall'input manager
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensibility * Time.deltaTime; // valore di rotazione sull'asse Y prese dall'input manager
        
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90, 90); // limite di rotazione del mouse X
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f); // Assegna alla rotazione della camera la posizione del Mouse X
        playerBody.Rotate(Vector3.up * mouseX);
    }
}
