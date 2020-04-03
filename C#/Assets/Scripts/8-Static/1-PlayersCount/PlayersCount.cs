using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThePlayer
{
    public int id;
    public string name;

    public static int playersCount;

    public void Player()
    {
        playersCount++;
    }
}

public class PlayersCount : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        ThePlayer _player1 = new ThePlayer();
        ThePlayer _player2 = new ThePlayer();
        ThePlayer _player3 = new ThePlayer();
        ThePlayer _player4 = new ThePlayer();

        Debug.Log("Number of players: " + ThePlayer.playersCount);
    }
}
