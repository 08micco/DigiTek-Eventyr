using UnityEngine;

/// <summary>
/// Får spilleren til at kunne kigge rundt samt bevæge sig. Locker cursoren til center af skærmen
/// </summary>

public class PlayerMovement : MonoBehaviour
{
    private CharacterController controller;
    public GameObject cam;

    // Hastigheden man går med
    private float movementSpeed = 6f;
    private float walkSpeed = 3f;
    private float runSpeed = 5f;
    private bool isRunning;
    private bool standingStill;

    private float x;
    private float z;

    // Tyngdekraften
    private float gravity = -9.816f * 4;
    private float velocity;

    // Højden man kan hoppe
    private float jumpHeight = 1f;
    private float jumpTime;
    
    // Lydeffekter
    private AudioSource audioSource;
    public AudioClip gravelWalk;
    public AudioClip gravelRun;
    public AudioClip jump;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        cam = GameObject.Find("PlayerCam");
        audioSource = gameObject.GetComponent<AudioSource>();
    }

    void Update()
    {
        // Spiller movement
        x = Input.GetAxis("Horizontal");
        z = Input.GetAxis("Vertical");
        
        // Flytter spilleren ift. hvor kameraet kigger hen
        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * (Time.deltaTime * movementSpeed));
        
        
        // Tyngdekraft
        velocity += gravity * Time.deltaTime;
        controller.Move(new Vector3(0, velocity, 0) * Time.deltaTime);
        
        
        // Spiller footsteps lydeffekter
        PlayFootstep();
        
        
        // Hvis spilleren har kontakt med jorden
        if (controller.isGrounded)
        {
            // Crouch
            Crouch();
            
            // Hoppe
            if (Input.GetKey(KeyCode.Space) && jumpTime >= 0.5f)
            {
                audioSource.Stop();
                audioSource.clip = jump;
                audioSource.Play();
                velocity = Mathf.Sqrt(jumpHeight * -2 * gravity);
                jumpTime = 0;
            }
            //Reset velocity
            if (velocity < 0) velocity = 0;
            // Løbe
            // Hvis man holder shift nede, bliver movementSpeed til runSpeed og ellers til walkSpeed
            movementSpeed = Input.GetKey(KeyCode.LeftShift) ? movementSpeed = runSpeed : movementSpeed = walkSpeed;
            // Boolen isRunning bliver sandt hvis movementSpeed er lig med runSpeed og ellers falsk
            isRunning = movementSpeed == runSpeed;
            jumpTime += Time.deltaTime;
        }
    }


    private void Crouch()
    {
        if (Input.GetKey(KeyCode.C /* "LeftControl" virker ikke så godt i editoren */))
        {
            cam.transform.localPosition = new Vector3(0, 0, 0);
        }
        else
        {
            cam.transform.localPosition = new Vector3(0, 0.8f, 0);
        }
    }
    
    
    private void PlayFootstep()
    {
        // Hvis man går og ikke løber
        if (isRunning == false)
        {
            // Ingen lyd bliver spillet hvis man står stille eller er i luften medmindre hoppe-lyd bliver spillet
            if (IsStandingStill() || !controller.isGrounded)
            {
                if(audioSource.clip != jump) audioSource.Stop();
            }
            // Spiller gå-lyd hvis
            else if (!audioSource.isPlaying || audioSource.clip != gravelWalk)
            {
                audioSource.Stop();
                audioSource.clip = gravelWalk;
                audioSource.Play();
            }
        }
        // Hvis man løber
        else if (isRunning)
        {
            // Ingen lyd bliver spillet hvis man står stille eller er i luften medmindre hoppe-lyd bliver spillet
            if (IsStandingStill() || !controller.isGrounded)
            {
                if(audioSource.clip != jump) audioSource.Stop();
            }
            // Spiller løbe-lyd
            else if (!audioSource.isPlaying || audioSource.clip != gravelRun)
            {
                audioSource.Stop();
                audioSource.clip = gravelRun;
                audioSource.Play();
            }
        }
    }
    
    // Returnere bool som bestemmer om man står stille eller ikke
    private bool IsStandingStill()
    {
        if (x != 0 || z != 0)
        {
            return standingStill = false;
        }
        else
        {
            return standingStill = true;
        }
    }
}
