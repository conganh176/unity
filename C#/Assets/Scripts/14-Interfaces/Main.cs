using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Interfaces
{
    public class Main : MonoBehaviour
    {
        // Update is called once per frame
        void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                Ray rayOrigin = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hitInfo;

                if (Physics.Raycast(rayOrigin, out hitInfo))
                {
                    /*if (hitInfo.collider.name == "Player")
                    {
                        Player player = hitInfo.collider.GetComponent<Player>();
                        player.Damage(100);
                    }
                    else if (hitInfo.collider.name == "Enemy")
                    {
                        Enemy enemy = hitInfo.collider.GetComponent<Enemy>();
                        enemy.Damage(100);
                    }*/
                    IDamagable<int> objectToClick = hitInfo.collider.GetComponent<IDamagable<int>>();

                    if (objectToClick != null)
                    {
                        objectToClick.Damage(100);
                    }
                }
            }
        }
    }
}
