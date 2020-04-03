using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Dictionary
{
    public class Player
    {
        public string name;
        public int id;

        public Player(int id)
        {
            this.id = id;
        }
    }

    public class CreatePlayer : MonoBehaviour
    {
        public Dictionary<int, Player> playerDictionary = new Dictionary<int, Player>();
        Player player2;
        void Start()
        {
            Player player1 = new Player(1);
            player1.name = "Swords";
            player2 = new Player(420);
            player2.name = "Leeroy";
            Player player3 = new Player(69);
            player3.name = "Todd";

            playerDictionary.Add(player1.id, player1);
            playerDictionary.Add(player2.id, player2);
            playerDictionary.Add(player3.id, player3);
        }

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                var player = playerDictionary[player2.id];
                Debug.Log("Player's name: " + player.name);
            }
        }
    }
}
