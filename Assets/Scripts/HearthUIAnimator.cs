using UnityEngine;

public class HearthUIAnimator : MonoBehaviour
{
    private Animator animator;

    [SerializeField] private GameHandler gameHandler;
    [SerializeField] private int hearthNumber;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    private void Start()
    {
        gameHandler.HealthReduced += GameHandler_HealthReduced;
        gameHandler.GameRestarted += GameHandler_GameRestarted;
    }

    private void GameHandler_GameRestarted(object sender, System.EventArgs e)
    {
        animator.SetBool("IsActive", true);
    }

    private void GameHandler_HealthReduced(object sender, int e)
    {
        if (hearthNumber == e)
        {
            animator.SetBool("IsActive", false);
        }
    }
}
