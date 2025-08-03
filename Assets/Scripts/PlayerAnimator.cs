using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{

    private Animator animator;

    [SerializeField] private Player player;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        Debug.Log(player.IsJumping());
        animator.SetBool("IsJumping", player.IsJumping());
    }
}
