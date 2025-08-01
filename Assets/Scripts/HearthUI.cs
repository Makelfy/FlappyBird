using UnityEngine;

public class HearthUI : MonoBehaviour
{
    [SerializeField] private GameHandler gameHandler;
    [SerializeField] private Transform hearth1;
    [SerializeField] private Transform hearth2;
    [SerializeField] private Transform hearth3;

    private void Start()
    {
        gameHandler.HealthReduced += GameHandler_HealthReduced;
    }

    private void GameHandler_HealthReduced(object sender, int e)
    {
        if (e == 2)
        {
            hearth3.gameObject.SetActive(false);
        }
        if (e == 1)
        {
            hearth2.gameObject.SetActive(false);
            hearth3.gameObject.SetActive(false);
        }
        if (e == 0)
        {
            hearth1.gameObject.SetActive(false);
            hearth2.gameObject.SetActive(false);
            hearth3.gameObject.SetActive(false);
        }
    }
}
