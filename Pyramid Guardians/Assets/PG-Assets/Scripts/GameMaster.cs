﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour
{
    private bool gameEnded = false;
    // Update is called once per frame
    void Update()
    {
        if(gameEnded)
        {
            return;
        }

        if(PlayerStats.Lives <= 0)
        {
            EndGame();
        }
    }

    void EndGame()
    {
        Debug.Log("Game Over!");
        gameEnded = true;
    }
}
