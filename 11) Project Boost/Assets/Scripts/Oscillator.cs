using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]     //Only allow 1 script component
public class Oscillator : MonoBehaviour
{
    [SerializeField] Vector3 movementVector = new Vector3(0f, 0f, 0f);
    [SerializeField] float period = 3f;

    [SerializeField] [Range(0, 1)] float movementFactor;

    Vector3 startingPosition;

    // Start is called before the first frame update
    void Start()
    {
        startingPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (period < Mathf.Epsilon)     //cant compare float
        {
            return;
        }

        float cycles = Time.time / period;

        const float tau = Mathf.PI * 2;     //6.28
        float rawSinWave = Mathf.Sin(cycles * tau);

        movementFactor = rawSinWave / 2f + 0.5f;

        Vector3 offset = movementFactor * movementVector;
        transform.position = startingPosition + offset;
    }
}
