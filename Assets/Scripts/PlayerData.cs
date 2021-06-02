using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public float Scores;
    public PlayerData(PlayerMovement playerScore)
    {
        Scores = playerScore.score;
    }



}
