using UnityEngine;
using UnityEngine.SceneManagement;

public class Rocket : MonoBehaviour
{
    [SerializeField] float rcsThrust = 100f;
    [SerializeField] float mainThrust = 100f;
    [SerializeField] float levelLoadDelay = 1f;

    //SFX
    [SerializeField] AudioClip mainEngine;
    [SerializeField] [Range(0, 1)] float mainEngineVolume = 0.5f;
    [SerializeField] AudioClip deadSound;
    [SerializeField] [Range(0, 1)] float deadSoundVolume = 0.5f;
    [SerializeField] AudioClip completeSound;
    [SerializeField] [Range(0, 1)] float completeSoundVolume = 0.5f;

    //Particle
    [SerializeField] ParticleSystem mainEngineEffect;
    [SerializeField] ParticleSystem successEffect;
    [SerializeField] ParticleSystem deadEffect;

    Rigidbody rigidbody;
    AudioSource audioSource;

    int currentSceneIndex;
    bool isTransitioning = false;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isTransitioning)
        {
            RespondToThrustInput();
            RespondToRotateInput();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (isTransitioning)
        {
            return;
        }

        switch (collision.gameObject.tag)
        {
            case "Friendly":
                break;
            case "Landing":
                StartComplete();
                break;
            default:
                StartDead();
                break;
        }
    }

    private void StartDead()
    {
        isTransitioning = true;
        audioSource.Stop();
        audioSource.PlayOneShot(deadSound, deadSoundVolume);
        deadEffect.Play();
        Invoke("ReloadScene", levelLoadDelay);
    }

    private void StartComplete()
    {
        isTransitioning = true;
        audioSource.Stop();
        audioSource.PlayOneShot(completeSound, completeSoundVolume);
        successEffect.Play();
        Invoke("LoadNextScene", levelLoadDelay);        //Delay method for 1f
    }

    private void LoadNextScene()
    {
        SceneManager.LoadScene(currentSceneIndex + 1);
    }
    private void ReloadScene()
    {
        SceneManager.LoadScene(currentSceneIndex);
    }

    private void RespondToThrustInput()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            ApplyThrust();
        }
        else
        {
            StopApplyingThrust();
        }
    }

    private void StopApplyingThrust()
    {
        audioSource.Stop();
        mainEngineEffect.Stop();
    }

    private void ApplyThrust()
    {
        rigidbody.AddRelativeForce(Vector3.up * mainThrust * Time.deltaTime);
        if (!audioSource.isPlaying)
        {
            audioSource.PlayOneShot(mainEngine, mainEngineVolume);
        }
        mainEngineEffect.Play();
    }

    private void RespondToRotateInput()
    {

        float rotationSpeed = rcsThrust * Time.deltaTime;

        if (Input.GetKey(KeyCode.A))
        {
            RotateManually(rotationSpeed);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            RotateManually(-rotationSpeed);
        }

    }

    private void RotateManually(float rotationSpeed)
    {
        rigidbody.freezeRotation = true;
        transform.Rotate(Vector3.forward * rotationSpeed);
        rigidbody.freezeRotation = false;
    }
}
