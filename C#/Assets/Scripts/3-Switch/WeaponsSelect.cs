using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponsSelect : MonoBehaviour
{
    [SerializeField] private int _weaponId;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            _weaponId = 1;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            _weaponId = 2;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            _weaponId = 3;
        }

        switch(_weaponId)
        {
            case 1:
                Debug.Log("Gun");
                break;
            case 2:
                Debug.Log("Knife");
                break;
            case 3:
                Debug.Log("Machine Gun");
                break;
            default:
                Debug.Log("Invalid");
                break;
        }
    }
}
