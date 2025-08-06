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
    }

    private void GameHandler_HealthReduced(object sender, int e)
    {
        if (hearthNumber == e)
        {
            animator.SetBool("IsActive", false);
        }
    }
}
