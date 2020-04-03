using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectsList : MonoBehaviour
{
    public GameObject[] _spawnList = new GameObject[3];
    public List<GameObject> _objectsCreated = new List<GameObject>();
    public int _spawnCount { get; set; }
    private bool _initColorChange = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (_spawnCount == 10)
            {
                _initColorChange = true;
                return;
            }

            var objectToBeSpawn = _spawnList[Random.Range(0, _spawnList.Length)];
            var x = Random.Range(-10, 10);
            var y = Random.Range(-10, 10);
            var position = new Vector3(x, y, 0);
            var theObject = Instantiate(objectToBeSpawn, position, Quaternion.identity);
            _objectsCreated.Add(theObject);
            _spawnCount++;
        }

        if (_initColorChange == true)
        {
            _initColorChange = false;
            foreach (var obj in _objectsCreated)
            {
                obj.GetComponent<MeshRenderer>().material.color = Color.green;
            }

            _objectsCreated.Clear();
        }
    }
}
