using UnityEngine;

public class End : MonoBehaviour
{
    public AudioSource wolfHowl;
    public GameObject enemies;
    
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.name == "EndWall")
        {
            Destroy(collision.gameObject);
            enemies.SetActive(true);
            wolfHowl.Play();
        }
    }
}
