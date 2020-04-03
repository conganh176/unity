using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class DeclaringProperties : MonoBehaviour
{
	private float _speed;

    public float Speed
	{
        get
		{
			return _speed;
		}
        private set
		{
			_speed = value;     //cannot access outside class
		}
	}

	private string _name;

    public string Name
	{
        get
		{
			return _name;
		}
		set
		{
			_name = value;      //can access outside class
		}
	}
    // Start is called before the first frame update
    void Start()
    {
		Speed = 10f;
		Debug.Log(Speed);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
