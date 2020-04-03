using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DelagatesEvents
{
    public class Callback : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            StartCoroutine(MyRoutine( () =>
                {
                    Debug.Log("The routine has completed");
                }
            ));
        }

        public IEnumerator MyRoutine(Action onComplete = null)
        {
            yield return new WaitForSeconds(2.0f);

            if (onComplete != null)
                onComplete();
        }
    }
}
