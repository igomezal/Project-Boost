using UnityEngine;

public class RocketShip : MonoBehaviour
{
    private Rigidbody rigidBody;
    private AudioSource audioSource;
    private GameManager gameManager;

    private bool isTransitioning = false;

    [SerializeField] private float rcsThrust= 100f;
    [SerializeField] private float thrustSpeed = 100f;

    [SerializeField] private AudioClip mainThrustClip;
    [SerializeField] private AudioClip reachGoalClip;
    [SerializeField] private AudioClip deathClip;

    [SerializeField] private ParticleSystem mainThrustParticles;
    [SerializeField] private ParticleSystem successParticles;
    [SerializeField] private ParticleSystem explosionParticles;

    private void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        
        if (gameManager == null)
        {
            Debug.LogError("gameManager is not defined");
        }
    }

    private void Update()
    {
        if (isTransitioning || PauseMenu.isGamePaused) return;
        Thrust();
        Rotate();
    }

    private void OnCollisionEnter(Collision other)
    {
        if (isTransitioning) return;
        
        if (other.gameObject.CompareTag("Hostile"))
        {
            RocketLoseControl();
            audioSource.PlayOneShot(deathClip);
            explosionParticles.Play();
            gameManager.PlayerLoses();
        } else if (other.gameObject.CompareTag("Goal"))
        {
            RocketLoseControl();
            audioSource.PlayOneShot(reachGoalClip);
            successParticles.Play();
            gameManager.PlayerWins();
        }
    }

    private void RocketLoseControl()
    {
        isTransitioning = true;
        mainThrustParticles.Stop();
        audioSource.Stop();
    }
    
    private void Thrust()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            rigidBody.AddRelativeForce(Vector3.up * (Time.deltaTime * thrustSpeed));
            if (!audioSource.isPlaying)
            {
                audioSource.PlayOneShot(mainThrustClip);
            }

            if (!mainThrustParticles.isPlaying)
            {
                mainThrustParticles.Play();
            }
        }
        else
        {
            audioSource.Stop();
            mainThrustParticles.Stop();
        }
    }

    private void Rotate()
    {
        rigidBody.angularVelocity = Vector3.zero;

        var rotationThisFrame = Time.deltaTime * rcsThrust;
        
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.forward * rotationThisFrame);
        }
        else if(Input.GetKey(KeyCode.D))
        {
            transform.Rotate(-Vector3.forward * rotationThisFrame);
        }
    }
}
