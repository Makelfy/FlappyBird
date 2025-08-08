using UnityEngine;

public class Grid : MonoBehaviour
{
    [SerializeField] private GameHandler gameHandler;
    [SerializeField] private float moveSpeedX = 1f;
    [SerializeField] private Player player;

    Vector3 startingPoint = new Vector3(0,0,0);

    private void Start()
    {
        gameHandler.HealthReduced += GameHandler_HealthReduced;
        gameHandler.GameOver += GameHandler_GameOver;
        gameHandler.GameRestarted += GameHandler_GameRestarted;
    }

    private void GameHandler_GameRestarted(object sender, System.EventArgs e)
    {
        transform.position = startingPoint;
    }

    private void GameHandler_GameOver(object sender, System.EventArgs e)
    {
        transform.position = startingPoint;
    }

    private void GameHandler_HealthReduced(object sender, int e)
    {
        transform.position = startingPoint;
    }

    void Update()
    {
        if (player.IsPlaying())
        {
            Vector3 moveVector = new Vector3(moveSpeedX, 0, 0);
            transform.position += moveVector * Time.deltaTime;
        }

    }
}
