using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace LINQ
{
    public class FindName : MonoBehaviour
    {
        public string[] names = { "alpha", "beta", "charlie", "alpha", "zebra" };
        void Start()
        {
            /*foreach (var name in names)
            {
                if (name == "beta")
                {
                    Debug.Log("Found beta");
                }
            }*/

            bool betaName = names.Any(name => name == "beta");
            Debug.Log("Found Beta name: " + betaName);

            //Cotains
            bool omegaName = names.Contains("omega");
            Debug.Log("Found Omega name: " + omegaName);

            //Distinct
            foreach (var name in names)
            {
                Debug.Log(name);
            }

            Debug.Log("Names after distinct: ");
            var uniqueNames = names.Distinct();
            foreach (var name in uniqueNames)
            {
                Debug.Log(name);
            }

            //Where
            Debug.Log("Names with more than 4 characters: ");
            var result = uniqueNames.Where(name => name.Length > 4);
            foreach (var name in result)
            {
                Debug.Log(name);
            }
        }
    }

}
