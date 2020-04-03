using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Singleton
{
    public class Player : MonoSingleton<Player>
    {
        public string playerName;

        public override void Init()
        {
            base.Init();

            Debug.Log("Player initialized");
        }
    }
}
