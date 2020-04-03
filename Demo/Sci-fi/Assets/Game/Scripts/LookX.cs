using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookX : MonoBehaviour
{
    [SerializeField] private float _mouseSensitivity = 1f;
    private float _mouseX;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _mouseX = Input.GetAxis("Mouse X");
        //transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, transform.localEulerAngles.y + (_mouseX * _mouseSensitivity), transform.localEulerAngles.z);      //Rotation;
        Vector3 newRotation = transform.localEulerAngles;
        newRotation.y += (_mouseX * _mouseSensitivity);
        transform.localEulerAngles = newRotation;
    }
}
