using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    
    // Horizontal rotation speed
    public float mouseSensitivity = 200f;
    // Vertical rotation speed
    float xRotation = 0f;
    public Transform playerBody;
    // Start is called before the first frame update
    void Start()
    {
        // Lock cursor til center af skærmen
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        // Rotation
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;
 
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f); // 30f for at skjule under lanterne
 
        // Rotere kameraet med de fundne værdier fra musen
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);
    }
}
