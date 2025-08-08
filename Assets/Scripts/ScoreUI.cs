using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreUI : MonoBehaviour
{
    [SerializeField] private GameHandler gameHandler;
    [SerializeField] private TextMeshProUGUI text;
    [SerializeField] private Player player;

    private void Start()
    {
        gameHandler.GameRestarted += GameHandler_GameRestarted;
        gameHandler.GameOver += GameHandler_GameOver;
    }

    private void GameHandler_GameOver(object sender, System.EventArgs e)
    {
        gameObject.SetActive(false);
    }

    private void GameHandler_GameRestarted(object sender, System.EventArgs e)
    {
        gameObject.SetActive(true);
    }

    private void Update()
    {
        text.text = "Score: " + player.CalculateScore();
    }
}
