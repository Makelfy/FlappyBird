using UnityEngine;

public class JumpToStartUI : MonoBehaviour
{

    [SerializeField] private GameHandler gameHandler;


    private void Start()
    {
        gameHandler.WaitingState += GameHandler_WaitingState;

        gameHandler.GamePlayingState += GameHandler_GamePlayingState;
    }

    private void GameHandler_GamePlayingState(object sender, System.EventArgs e)
    {
        gameObject.SetActive(false);
    }

    private void GameHandler_WaitingState(object sender, System.EventArgs e)
    {
        gameObject.SetActive(true);
    }
}
