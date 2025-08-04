using UnityEngine;

public class GameOverUI : MonoBehaviour
{

    [SerializeField] private GameHandler gameHandler;

    private void Start()
    {
        gameObject.SetActive(false);
        gameHandler.GameOver += GameHandler_GameOver;
    }

    private void GameHandler_GameOver(object sender, System.EventArgs e)
    {
        gameObject.SetActive(true);
    }
}
