using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace LINQ
{
    [System.Serializable]
    public class Item
    {
        public string name;
        public int id;
        public int buff;
    }
    public class FilterItems : MonoBehaviour
    {
        public List<Item> items;
        // Start is called before the first frame update
        void Start()
        {
            var result = items.Any(item => item.id > 1);
            Debug.Log("Result: " + result);

            var result2 = items.Where(item => item.buff > 20);
            foreach (var item in result2)
            {
                Debug.Log(item.name);
            }


        }
    }
}
