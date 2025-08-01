using System;
using UnityEngine;

public class GameHandler : MonoBehaviour
{

    public event EventHandler<int> HealthReduced;
    public event EventHandler GameOver;


    [SerializeField] private Player player;

    private enum State
    {
        WaitingToStart,
        CountdownToStart,
        GamePlaying,
        PlayerCollided,
        GameOver,
    }
    private State state;
    private float waitingToStartTimer = 1f;
    private float countdownToStartTimer = 1f;

    private void Awake()
    {
        state = State.WaitingToStart;
    }

    private void Start()
    {
        player.PlayerCollided += Player_PlayerCollided;
    }

    private void Player_PlayerCollided(object sender, int e)
    {
        HealthReduced?.Invoke(this, e);
        if (e > 0)
        {
            state = State.PlayerCollided;
        }
        else
        {
            state = State.GameOver;
        }
    }

    void Update()
    {
        switch(state)
        {
            case State.WaitingToStart:
                waitingToStartTimer -= Time.deltaTime;
                if (waitingToStartTimer < 0f)
                {
                    state = State.CountdownToStart;
                }
                break;
            case State.CountdownToStart:
                countdownToStartTimer -= Time.deltaTime;
                if (countdownToStartTimer < 0f)
                {
                    state = State.GamePlaying;
                }
                break;
            case State.GamePlaying:
                break;
            case State.PlayerCollided:
                break;
            case State.GameOver:
                GameOver?.Invoke(this, EventArgs.Empty);
                Debug.Log("Game is Over!!");
                break;
        }
    }
}
