using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Colors : MonoBehaviour
{
    [SerializeField] private int _nextColor;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            _nextColor = 0;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            _nextColor = 1;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            _nextColor = 2;
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            _nextColor = 3;
        }

        switch(_nextColor)
        {
            case 0:
                Debug.Log("Blue");
                break;
            case 1:
                Debug.Log("Red");
                break;
            case 2:
                Debug.Log("Green");
                break;
            case 3:
                Debug.Log("Black");
                break;
            default:
                break;
        }
    }
}
