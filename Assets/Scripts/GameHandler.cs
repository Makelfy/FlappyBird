using UnityEngine;

public class GameHandler : MonoBehaviour
{
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

    // Update is called once per frame
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
                if(!Movement.Instance.IsAlive())
                {
                    state = State.GameOver;
                }
                break;
            case State.GameOver:
                break;
        }
    }
}
