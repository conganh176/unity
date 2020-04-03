using UnityEngine;

public class Ball : MonoBehaviour
{
    //config params
    [SerializeField] Paddle paddle1;
    [SerializeField] float xPush = 2f;
    [SerializeField] float yPush = 15f;
    [SerializeField] AudioClip[] ballSounds;
    [SerializeField] float randomFactor = 0.2f;

    //state
    Vector2 paddleToBallVector;
    bool hasStarted = false;

    //Cached component references
    AudioSource myAudioSource;
    Rigidbody2D myRigidBody2D;

    // Start is called before the first frame update
    void Start()
    {
        //Vector2 ballPosition = transform.position;
        //Vector2 paddle1Position = paddle1.transform.position; 
        //paddleToBallVector = ballPosition - paddle1Position;
        paddleToBallVector = transform.position - paddle1.transform.position;
        myAudioSource = GetComponent<AudioSource>();        //Find AudioSource component
        myRigidBody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!hasStarted)
        {
            LockBallToPaddle();
            LaunchOnMouseClick();
        }
    }


    private void LockBallToPaddle()
    {
        var paddlePosition = new Vector2(paddle1.transform.position.x, paddle1.transform.position.y);
        transform.position = paddlePosition + paddleToBallVector;
    }

    private void LaunchOnMouseClick()
    {
        if (Input.GetMouseButtonDown(0))    //Left mouse clicked
        {
            hasStarted = true;
            myRigidBody2D.velocity = new Vector2(xPush, yPush);        //Access velocity

        }
    }

    public void SetBallStop()
    {
        hasStarted = false;
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        var velocityTweak = new Vector2(
            Random.Range(0f, randomFactor),
            Random.Range(0f, randomFactor)
            );

        if (hasStarted)
        {
            AudioClip audio = ballSounds[UnityEngine.Random.Range(0, ballSounds.Length)];       //Random audio from audio arrays
            myAudioSource.PlayOneShot(audio);
            myRigidBody2D.velocity += velocityTweak;
        }
    }
}
