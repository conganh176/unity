using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InscreaseSpeed : MonoBehaviour
{
    [SerializeField] private int _speed;
    [SerializeField] private int _maxSpeed;
    // Start is called before the first frame update
    void Start()
    {
        _maxSpeed = Random.Range(60, 120);
        StartCoroutine(SpeedRoutine());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpeedRoutine()
    {
        while(true)
        {
            yield return new WaitForSeconds(1f);
            _speed += 5;

            if (_speed > _maxSpeed)
            {
                break;
            }
        }
    }
}
