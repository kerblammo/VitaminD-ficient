using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class EndEventBroker
{
    public delegate void EndRoundEventHandler();
    public static event EndRoundEventHandler EndRoundEvent;

    public delegate void GameOverEventHandler();
    public static event GameOverEventHandler GameOverEvent;

    public static void EndRound()
    {
        EndRoundEvent();
    }

    public static void GameOver()
    {
        GameOverEvent();
    }

}
