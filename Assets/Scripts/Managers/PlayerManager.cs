using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerManager : MonoBehaviour // for things relating to state
{
    public static PlayerManager instance;

    public PlayerState currentPlayerState;

    public event Action onDeath;
    public event Action onPause;
    public event Action onDialogue;
    public event Action onLive;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }   
    }

    //triggers when player health below 0 from player stats
    public void TriggerDeath()
    {
        onDeath?.Invoke();
        currentPlayerState = PlayerState.Dead;
    }

    public void TriggerPause()
    {
        onPause?.Invoke();
        currentPlayerState = PlayerState.Pause;
    }

    public void TriggerDialogue()
    {
        onDialogue?.Invoke();
        currentPlayerState = PlayerState.Dialogue;
    }

    public void TriggerLive()
    {
        onLive?.Invoke();
        currentPlayerState = PlayerState.Live;
    }

}

public enum PlayerState
{
    Live,
    Dead,
    Pause,
    Dialogue,
}
