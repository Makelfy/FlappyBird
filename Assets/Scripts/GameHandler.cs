using UnityEngine;

public class GameHandler : MonoBehaviour
{

    [SerializeField] private Player player;

    private enum State
    {
        WaitingToStart,
        CountdownToStart,
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
    }

    private void Player_PlayerCollided(object sender, System.EventArgs e)
    {
        state = State.GameOver;
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
                if(!Player.Instance.IsAlive())
                {
                    state = State.GameOver;
                }
                break;
            case State.GameOver:
                Debug.Log("Game is Over!!");
                break;
        }
    }
}
