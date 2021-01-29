using UnityEngine;

public class Lanterne : MonoBehaviour
{
    public Camera p_Camera;

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(p_Camera.transform.position, Vector3.up);
    }
}
