using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectPoints : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private int _points;
    [SerializeField] private bool _isComplete = false;
    void Start()
    {
        _points = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _points += 10;
        }

        if (_points >= 50 && !_isComplete)
        {
            Debug.Log("You are awesome");
            _isComplete = true;
        }
    }
}
