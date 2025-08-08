using System;
using UnityEngine;

public class GameHandler : MonoBehaviour
{

    public event EventHandler<int> HealthReduced;
    public event EventHandler GameOver;
    public event EventHandler WaitingState;
    public event EventHandler GamePlayingState;
    public event EventHandler GameRestarted;

    [SerializeField] private Player player;
    [SerializeField] private GameOverUI gameOverUI;

    private enum State
    {
        WaitingToStart,
        GamePlaying,
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
        player.PlayerStarted += Player_PlayerStarted;
        gameOverUI.RestartGame += GameOverUI_RestartGame;
    }

    private void GameOverUI_RestartGame(object sender, EventArgs e)
    {
        GameRestarted?.Invoke(this, EventArgs.Empty);
        state = State.WaitingToStart;
    }

    private void Player_PlayerStarted(object sender, EventArgs e)
    {
        if (state == State.WaitingToStart)
        {
            state = State.GamePlaying;
        }
    }

    private void Player_PlayerCollided(object sender, int e)
    {
        HealthReduced?.Invoke(this, e);
        if (e > 0)
        {
            state = State.WaitingToStart;
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
                WaitingState?.Invoke(this, EventArgs.Empty);
                break;
            case State.GamePlaying:
                GamePlayingState?.Invoke(this, EventArgs.Empty);
                break;
            case State.GameOver:
                GameOver?.Invoke(this, EventArgs.Empty);
                break;
        }
    }

}
