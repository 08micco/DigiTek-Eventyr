using UnityEngine;

public class AmbientSound : MonoBehaviour
{
    public AudioSource audioSource;
    
    void Start()
    {
        audioSource.Play();
    }

}
