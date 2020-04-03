using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncreaseSpeed : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private int _speed = 0;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            _speed += 5;
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            _speed -= 5;
        }

        if (_speed > 20)
        {
            Debug.Log("Slow down!!!");
        }
        else if (_speed == 0)
        {
            Debug.Log("Speed Up!!!");
        }

        if (_speed < 0)
        {
            _speed = 0;
        }
    }
}
